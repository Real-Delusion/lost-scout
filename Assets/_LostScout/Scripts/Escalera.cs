using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escalera : MonoBehaviour
{
    /*// radio desde el cual se podrá interactuar
    public float radio = 1.5f;

    // player
    private GameObject player;

    // script playercontroller del player
    private PlayerController playerController;

    // altura del game object, para luego asignar la nueva posición al player
    private float miAltura;


    // Start is called before the first frame update
    void Start()
    {
        // guardamos el player con el tag
        player = GameObject.FindGameObjectWithTag("Player");

        // accedemos a su script de playercontroller
        playerController = player.GetComponent<PlayerController>();        
        
        miAltura = GetComponent<Collider>().bounds.size.y;

    }

    // Update is called once per frame
    void Update()
    {
        // Si el jugador entra en el radio del objeto
        if (Vector3.Distance(player.transform.position, transform.position) < radio)
        {
            // Si está en el radio y pulsa espacio
            if (Input.GetKeyDown(KeyCode.Space) | Input.GetKeyDown("joystick button 0"))
            {
                Debug.Log("Se puede subir");
                // mandamos la posición y la altura de la caja al otro script
                // el script playercontroller cambiará la posición del player usando estos parámetros
                playerController.alturaEscalera = miAltura;

                // cambiamos el estado del player a subir
                playerController.Estado = PlayerController.EstadosPlayer.SubirEscalera;
            }

        }
    }

    // para ver el radio en la escena
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radio);
    } */

    GameObject player;
    bool canClimb = false;
    public float speed = 1;

    // script playercontroller del player
    private PlayerController playerController;

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player" && player.transform.position.y < (transform.localScale.y))
        {
            Debug.Log("true");
            canClimb = true;
            player.GetComponent<PlayerController>().Estado = PlayerController.EstadosPlayer.SubirEscalera;
        }
    }

    void OnTriggerExit(Collider coll2)
    {
        if (coll2.gameObject.tag == "Player")
        {
            Debug.Log("false");
            canClimb = false;
            player.GetComponent<PlayerController>().Estado = PlayerController.EstadosPlayer.Andar;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // guardamos el player con el tag
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
    }
    void Update()
    {
    }
}
