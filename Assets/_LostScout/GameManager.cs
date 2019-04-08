using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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


    public bool gamePaused = false;

    // *** GENERIC GAME OBJECTS ***
    GameObject player;
    GameObject camera;
    GameObject checkpoint;

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
        }
        else if (instance != this) //If instance already exists and it's not this:
        {
            Destroy(gameObject); //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
        }

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        // Get different component managers
        nivelesManager = GetComponent<NivelesManager>();
        uiManager = GetComponent<UIManager>();

        //Call the InitGame function to initialize the game
        InitGame();

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
            nivelesManager.printLevels(niveles);
        }

        // Disable cursor and get generic game objects if we are in a playable level
        if (currentScene.name.Contains("Nivel "))
        {
            Cursor.visible = false;
            player = GameObject.FindGameObjectWithTag("Player");
            camera = GameObject.FindGameObjectWithTag("MainCamera");
            checkpoint = GameObject.FindGameObjectWithTag("checkpoint");
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
            new Nivel(1,"Nivel 1",false,0,false,60,1),
            new Nivel(2,"Nivel 2",false,0,false,60,5),
            new Nivel(3,"Nivel 3",false,0,false,60,5),
            new Nivel(3,"Nivel 4",false,0,true,60,5)
        };

        // Load saved data
        // ...
    }

    // Update is called once per frame
    void Update()
    {
        // For all level scenes
        if (currentScene.name.Contains("Nivel "))
        {

            // Check for the checkpoint
            if (Vector3.Distance(player.transform.position, checkpoint.transform.position) < radioCheckpoint)
            {
                // aquí incluir animación del player
                SceneManager.LoadScene("MainMenuScreen");
            }

            // Check for pause/rsume game
            if (Input.GetKeyDown(KeyCode.Escape) | Input.GetKeyDown("joystick button 7"))
            {
                if(gamePaused){
                    ResumeGame();
                }else
                {
                    PauseGame();
                }
            }
        }

    }

    public void ResumeGame(){
        uiManager.toggleMenuPausa();
        enableInput(true);
        gamePaused = !gamePaused;
    }

    public void PauseGame(){
        uiManager.toggleMenuPausa();
        enableInput(false);
        gamePaused = !gamePaused;
    }

    // Enable/disable player input
    public void enableInput(bool state)
    {
        player.GetComponent<PlayerController>().enabled = state;
        camera.GetComponent<Camara>().enabled = state;
    }

}
