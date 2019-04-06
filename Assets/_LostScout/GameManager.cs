using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Static instance of GameManager which allows it to be accessed by any other script.
    public static GameManager instance = null;
    public List<Nivel> niveles;
    public NivelesManager nivelesManager;
    
    GameObject player;
    GameObject checkpoint;

    // radio desde el cual se podrá cambiar de escena tocando el checkpoint
    public float radioCheckpoint = 1.0f;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        //checkpoint = GameObject.FindGameObjectWithTag("checkpoint");
        //Gizmos.DrawWireSphere(checkpoint.transform.position, radioCheckpoint);
    }

    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if(instance == null){
            instance = this; //if not, set instance to this
            InitGame(); //Call the InitGame function to initialize the game
        }else if (instance != this){ //If instance already exists and it's not this:
            Destroy(gameObject); //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
        }
        
        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
        
        // Hide cursor
        Cursor.visible = false;

        nivelesManager = GetComponent<NivelesManager>();

        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene ();

        // Enable cursor and print levels if we are in SeleccionNivel scene
        if(currentScene.name == "SeleccionNivel"){
            Cursor.visible = true;
            nivelesManager.printLevels(niveles);
        }

        // Enable cursor if we are in MainMenuScreen scene
        if(currentScene.name == "MainMenuScreen"){
            Cursor.visible = true;
        }


        /*player = GameObject.FindGameObjectWithTag("Player");
        checkpoint = GameObject.FindGameObjectWithTag("checkpoint");
        */
    }

    void InitGame(){
        // Create Levels
        niveles =  new List<Nivel>();

        var nivel1 = new Nivel(1,"Nivel 1",false,0,false,60,1);
        var nivel2 = new Nivel(2,"Nivel 2",false,0,false,60,5);
        var nivel3 = new Nivel(3,"Nivel 3",false,0,true,60,5);
        
        niveles.Add(nivel1);
        niveles.Add(nivel2);
        niveles.Add(nivel3);
    }

    // Update is called once per frame
    void Update()
    {/*
        Debug.Log(Vector3.Distance(player.transform.position, checkpoint.transform.position));
        if (Vector3.Distance(player.transform.position, checkpoint.transform.position) < radioCheckpoint)
        {
            // aquí incluir animación del player
            SceneManager.LoadScene("SeleccionNivel");
        }
         */
    }

}
