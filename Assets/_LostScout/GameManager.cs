using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;

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
    public bool fromGame = false;
    controlCamaraMenu controlMenu;

    // *** GENERIC GAME OBJECTS ***
    GameObject player;
    GameObject camera;
    GameObject checkpoint;

    public float startTime;
    public int numInteractions = 0;
    public float time;

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
            Cursor.visible = false;
            startTime = Time.time;
            player = GameObject.FindGameObjectWithTag("Player");
            camera = GameObject.FindGameObjectWithTag("MainCamera");
            checkpoint = GameObject.FindGameObjectWithTag("checkpoint");

            // Show hud
            uiManager.toggleHUD(true);

            //Looking for the name of the level
            int index = niveles.FindIndex(x => x.LevelName.Equals(currentScene.name));
            string levelName = niveles[index].LevelName;

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
        // Create Levels
        niveles = new List<Nivel>()
        {
            new Nivel(0,"Level Tutorial",false,0,false,120,50),
            new Nivel(1,"Level 1",false,0,true,20,2),
            new Nivel(2,"Level 2",false,0,true,50,4),
            new Nivel(3,"Level 3",false,0,true,60,7),
            new Nivel(4,"Level 4",false,0,true,120,8),
            new Nivel(5,"Level 5",false,0,true,60,8),
            new Nivel(6,"Level 6",false,0,true,60,8),
            new Nivel(7,"Level 7",false,0,true,60,8),
            new Nivel(8,"Level 8",false,0,true,60,8),
            new Nivel(9,"Level 9",false,0,true,60,8),
            new Nivel(10,"Level 10",false,0,true,60,8),
            new Nivel(11,"Level 11",false,0,true,60,8),
            new Nivel(12,"Level 12",false,0,true,60,5)
        };

        // Load saved data
        // ...
    }

    // Update is called once per frame
    void Update()
    {
        // For all level scenes
        if (currentScene.name.Contains("Level "))
        {
            time = (Time.time) - startTime;
            uiManager.printTime(time, gamePaused);
            // Check for the checkpoint
            if ((Vector3.Distance(player.transform.position, checkpoint.transform.position) < radioCheckpoint))
            {
                // aquí incluir animación del player
                finishLevel();
            }

            // Check for pause/resume game
            if (Input.GetKeyDown(KeyCode.Escape) | Input.GetKeyDown("joystick button 7"))
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
        // Move player to avoid a loop on checkpoint
        player.transform.position = new Vector3((player.transform.position.x) + 1, player.transform.position.y, player.transform.position.z);
        player.gameObject.SetActive(false);

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

        //Show texto bien hecho
        uiManager.showBienHecho();
        //Esperar 5 segundos para mostrar el menuPuntuacion
        StartCoroutine(Wait(insignias, time));

        numInteractions = 0;
    }

    // Enable/disable player input
    public void enableInput(bool state)
    {
        player.GetComponent<PlayerController>().enabled = state;
        camera.GetComponent<Camara>().enabled = state;
    }

    IEnumerator Wait(int insignias, float time)
    {
        yield return new WaitForSecondsRealtime(3);
        // Show menu puntuacion (pass insignias and time)
        uiManager.hideBienHecho();
        uiManager.showMenuPuntuacion(insignias, time);
    }


    IEnumerator WaitLevelName(string levelName)
    {
        yield return new WaitForSecondsRealtime(0.8f);
        //Show nombre del nivel
        uiManager.showLevelName(levelName);
        yield return new WaitForSecondsRealtime(3);
        // Show menu puntuacion (pass insignias and time)
        uiManager.hideLevelName();

    }

}
