using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<Nivel> niveles;
    
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

    // Start is called before the first frame update
    void Start()
    {
        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene ();

        // Create Levels
        niveles =  new List<Nivel>();

        var nivel1 = new Nivel(1,"Nivel 1",false,0,false,60,1);
        var nivel2 = new Nivel(2,"Nivel 2",false,0,false,60,5);
        var nivel3 = new Nivel(3,"Nivel 3",false,0,true,60,5);
        
        niveles.Add(nivel1);
        niveles.Add(nivel2);
        niveles.Add(nivel3);

        Cursor.visible = false;
        /*player = GameObject.FindGameObjectWithTag("Player");
        checkpoint = GameObject.FindGameObjectWithTag("checkpoint");
        */
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
