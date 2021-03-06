﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameManager : MonoBehaviour
{
    //Static instance of GameManager which allows it to be accessed by any other script.
    public static GameManager instance = null;

    // Current scene name
    Scene currentScene;
    // radio desde el cual se podrá cambiar de escena tocando el checkpoint
    public static float radioCheckpoint = 1.5f;

    // Where levels are stored
    public static List<Nivel> niveles;

    // *** MANAGERS
    public NivelesManager nivelesManager;
    public UIManager uiManager;
    private Tutorial tutorialScript;

    public static SceneTransitions sceneTransitions;
    public bool gamePaused = false;
    public bool finishedLevel = false;
    public bool fromGame = false;
    controlCamaraMenu controlMenu;

    // *** GENERIC GAME OBJECTS ***
    GameObject player;
    new GameObject camera;
    GameObject checkpoint;

    public float startTime;
    public int numInteractions = 0;
    public float time;
    bool levelStarted = false;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        //checkpoint = GameObject.FindGameObjectWithTag("checkpoint");
        //Gizmos.DrawWireSphere(checkpoint.transform.position, radioCheckpoint);
    }

    //Awake is always called before any Start functions (called zero)
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)
        {
            //if not, set instance to this
            instance = this;

            // Get different component managers
            nivelesManager = GetComponent<NivelesManager>();
            uiManager = GetComponent<UIManager>();
            sceneTransitions = GetComponent<SceneTransitions>();
            tutorialScript = GetComponent<Tutorial>();

            //Sets this to not be destroyed when reloading scene
            DontDestroyOnLoad(gameObject);
            //Call the InitGame function to initialize the game
            InitGame();
        }
        else if (instance != this) //If instance already exists and it's not this:
        {
            DestroyImmediate(gameObject); //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
        }

        // Get actual scene name
        currentScene = SceneManager.GetActiveScene();
    }
    // Called first
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Each time a scene is loaded (called second)
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Get actual scene name
        currentScene = SceneManager.GetActiveScene();

        // Enable cursor and print levels if we are in MainMenuScreen scene
        if (currentScene.name == "MainMenuScreen")
        {
            finishedLevel = false;
            Cursor.visible = true;
            nivelesManager.printLevels();
            // Hide hud
            uiManager.toggleHUD(false);

            if (fromGame)
            {
                Camera mainCamera = Camera.main;
                controlMenu = mainCamera.GetComponent<controlCamaraMenu>();
                controlMenu.fromGame = true;
            }
        }

        // Disable cursor and get generic game objects if we are in a playable level
        if (currentScene.name.Contains("Level "))
        {
            time = 0f;
            levelStarted = false;
            Cursor.visible = false;
            player = GameObject.FindGameObjectWithTag("Player");
            camera = GameObject.FindGameObjectWithTag("MainCamera");
            checkpoint = GameObject.FindGameObjectWithTag("checkpoint");
            uiManager.printTime(0, false);

            // Show hud
            uiManager.toggleHUD(true);

            //Looking for the name of the level
            int index = niveles.FindIndex(x => x.LevelName.Equals(currentScene.name));
            string levelName = niveles[index].Title;

            PauseGame(false);
            //Show nombre del nivel
            StartCoroutine(WaitLevelName(levelName));
        }
    }

    // called third
    void Start()
    {
    }

    // called when the game is terminated
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Function to init the game
    void InitGame()
    {
        // Load saved data
        load();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("gamkemkal"+nivelesManager.unlockedId);
        // For all level scenes
        if (currentScene.name.Contains("Level "))
        {
            if (levelStarted) time = (Time.time) - startTime;
            //Debug.Log(time);
            uiManager.printTime(time, gamePaused);
            // Check for the checkpoint
            if ((Vector3.Distance(player.transform.position, checkpoint.transform.position) < radioCheckpoint) && finishedLevel == false)
            {
                finishedLevel = true;
                // aquí incluir animación del player
                finishLevel();
            }

            // Check for pause/resume game
            if (Input.GetKeyDown(KeyCode.Escape) | Input.GetKeyDown("joystick button 7") && !finishedLevel)
            {
                if (gamePaused)
                {
                    ResumeGame(true);
                }
                else
                {
                    PauseGame(true);
                }
            }

            if (Input.GetKeyDown(KeyCode.E) | Input.GetKeyDown("joystick button 0"))
            {
                numInteractions++;
            }
            
        }

    }

    // Resume game function (with or without menu)
    public void ResumeGame(bool ui)
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        if (currentScene.name == "Level Tutorial") GameObject.Find("Canvas").GetComponent<Canvas>().enabled = true;
        if (ui)
        {
            uiManager.toggleMenuPausa(false);
        }
        enableInput(true);
        gamePaused = false;
    }

    // Pause game function (with or without menu)
    public void PauseGame(bool ui)
    {
        Cursor.visible = true;
        if (currentScene.name == "Level Tutorial") GameObject.Find("Canvas").GetComponent<Canvas>().enabled = false;
        if (ui)
        {
            uiManager.toggleMenuPausa(true);
            Time.timeScale = 0;
        }
        enableInput(false);
        gamePaused = true;
    }

    // Called when player collides on the checkpoint
    public void finishLevel()
    {
        player.GetComponent<PlayerController>().Estado = PlayerController.EstadosPlayer.Quieto;

        if (currentScene.name == "Level Tutorial") {
            GameObject.Find("Canvas").GetComponent<Tutorial>().hideEverything();
        }
        // Pause the game without graphic interface
        PauseGame(false);

        // Get level index
        int index = niveles.FindIndex(x => x.LevelName.Equals(currentScene.name));

        // Unlock this level (for tutorial)
        niveles[index].Locked = false;

        // Unlock next level if it's locked
        if (niveles[index + 1].Locked == true) {
            niveles[index + 1].Locked = false;
            nivelesManager.unlockedId = index + 1;
        }

        // Insignias, by default is one (Obsequio)
        int insignias = 1;

        // Get time and (optionally) add insignia
        insignias++;

        // Get interactions and (optionally) add insignia
        if (numInteractions <= niveles[index].MaxInteractions)
        {
            insignias++;
        }

        // Set insignias
        niveles[index].Insignias = insignias;

        // Set completed
        niveles[index].Completed = true;

        // Set time
        if (time < niveles[index].RecordTime || niveles[index].RecordTime == -1) niveles[index].RecordTime = time;

        //Show texto bien hecho
        uiManager.showBienHecho();
        //Esperar 5 segundos para mostrar el menuPuntuacion
        StartCoroutine(Wait(insignias, time, niveles[index].RecordTime));

        numInteractions = 0;

        save();
    }

    // Enable/disable player input
    public void enableInput(bool state)
    {
        player.GetComponent<PlayerController>().enabled = state;
        camera.GetComponent<Camara>().enabled = state;
    }

    IEnumerator Wait(int insignias, float time, float record)
    {
        yield return new WaitForSecondsRealtime(3);
        // Show menu puntuacion (pass insignias and time)
        uiManager.hideBienHecho();
        uiManager.showMenuPuntuacion(insignias, time, record);
    }


    IEnumerator WaitLevelName(string levelName)
    {
        //yield return new WaitForSecondsRealtime(0.8f);
        //Show nombre del nivel
        uiManager.showLevelName(levelName);
        if (currentScene.name == "Level Tutorial")
        GameObject.Find("Canvas").GetComponent<Canvas>().enabled = false;
        yield return new WaitForSecondsRealtime(3);
        // Show menu puntuacion (pass insignias and time)
        uiManager.hideLevelName();
        ResumeGame(false);
        startTime = Time.time;
        levelStarted = true;
        time = 0f;
    }

    public void save(){
        BinaryFormatter bf = new BinaryFormatter();
        Debug.Log(Application.persistentDataPath);
        FileStream file = File.Create (Application.persistentDataPath + "/savedGames.gd");
        bf.Serialize(file, niveles);
        file.Close();
    }

    public static void load() {
        if(File.Exists(Application.persistentDataPath + "/savedGames.gd")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
            niveles = (List<Nivel>)bf.Deserialize(file);
            file.Close();
        }else{
            niveles = new List<Nivel>()
            {
               new Nivel(0,"Level Tutorial","Get Started",false,0,false,120,50, -1, true),
                new Nivel(1,"Level 1","Mount\nEverest",false,0,true,5,2, -1, true),
                new Nivel(2,"Level 2","Tricky\nHills",false,0,true,20,5, -1, true),
                new Nivel(3,"Level 3","Across\nthe River",false,0,true,20,3, -1, true),
                new Nivel(4,"Level 4","Starry\nNight",false,0,true,20,4, -1, true),
                new Nivel(5,"Level 5","Niagara\nFalls",false,0,true,45,12, -1, true),
                new Nivel(6,"Level 6","Third Time\nLucky",false,0,true,30,8, -1, true),
                new Nivel(7,"Level 7","After the\nStorm",false,0,true,45,9, -1, true),
                new Nivel(8,"Level 8","Level 8",false,0,true,60,8, -1, false),
                new Nivel(9,"Level 9","Level 9",false,0,true,60,8, -1, false),
                new Nivel(10,"Level 10","Level 10",false,0,true,60,8, -1, false),
                new Nivel(11,"Level 11","Level 11",false,0,true,60,8, -1, false),
                new Nivel(12,"Level 12","Level 12",false,0,true,60,5, -1, false) 

             /*   new Nivel(0,"Level Tutorial","Get Started",false,0,false,120,50, -1, true),
                new Nivel(1,"Level 1","Mount\nEverest",false,0,false,5,2, -1, true),
                new Nivel(2,"Level 2","Tricky\nHills",false,0,false,20,5, -1, true),
                new Nivel(3,"Level 3","Across\nthe River",false,0,false,20,3, -1, true),
                new Nivel(4,"Level 4","Starry\nNight",false,0,false,20,4, -1, true),
                new Nivel(5,"Level 5","Niagara\nFalls",false,0,false,45,12, -1, true),
                new Nivel(6,"Level 6","Third Time\nLucky",false,0,false,30,8, -1, true),
                new Nivel(7,"Level 7","After the\nStorm",false,0,false,45,9, -1, true),
                new Nivel(8,"Level 8","Level 8",false,0,false,60,8, -1, false),
                new Nivel(9,"Level 9","Level 9",false,0,false,60,8, -1, false),
                new Nivel(10,"Level 10","Level 10",false,0,false,60,8, -1, false),
                new Nivel(11,"Level 11","Level 11",false,0,false,60,8, -1, false),
                new Nivel(12,"Level 12","Level 12",false,0,false,60,5, -1, false) */
            };
        }
    }

}
