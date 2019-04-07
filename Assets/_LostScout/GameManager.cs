using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Static instance of GameManager which allows it to be accessed by any other script.
    public static GameManager instance = null;
    Scene currentScene;
    public static List<Nivel> niveles;
    public NivelesManager nivelesManager;
    
    GameObject player;
    GameObject checkpoint;

    // radio desde el cual se podrá cambiar de escena tocando el checkpoint
    public static float radioCheckpoint = 1.5f;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        //checkpoint = GameObject.FindGameObjectWithTag("checkpoint");
        //Gizmos.DrawWireSphere(checkpoint.transform.position, radioCheckpoint);
    }

    //Awake is always called before any Start functions
    // called zero
    void Awake()
    {
        //Check if instance already exists
        if(instance == null){
            instance = this; //if not, set instance to this
            
        }else if (instance != this){ //If instance already exists and it's not this:
            Destroy(gameObject); //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
        }
        
        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
        
        // Hide cursor
        Cursor.visible = false;
        
        nivelesManager = GetComponent<NivelesManager>();
        InitGame(); //Call the InitGame function to initialize the game


        // Create a temporary reference to the current scene.
        currentScene = SceneManager.GetActiveScene ();
    }
    // called first
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        currentScene = SceneManager.GetActiveScene ();

        // Enable cursor and print levels if we are in MainMenuScreen scene
        if(currentScene.name == "MainMenuScreen"){
            Cursor.visible = true;
            nivelesManager.printLevels(niveles);
        }

        if(currentScene.name == "Nivel 1"){
            player = GameObject.FindGameObjectWithTag("Player");
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

    void InitGame(){
        // Create Levels
        niveles =  new List<Nivel>()
        {
            new Nivel(1,"Nivel 1",false,0,false,60,1),
            new Nivel(2,"Nivel 2",false,0,false,60,5),
            new Nivel(3,"Nivel 3",false,0,true,60,5)
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (currentScene.name == ("Nivel 1")){
            //Debug.Log(Vector3.Distance(player.transform.position, checkpoint.transform.position)+"   "+radioCheckpoint);
            if (Vector3.Distance(player.transform.position, checkpoint.transform.position) < radioCheckpoint)
            {
            // aquí incluir animación del player
            SceneManager.LoadScene("MainMenuScreen");
            }
        }
         
    }

}
