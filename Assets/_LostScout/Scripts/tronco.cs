using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

// Este script se asigna a un gameobject al que el player se podrá subir

public class tronco : MonoBehaviour
{
    // *** GLOBAL ***
     // Minimum distance to pickup
    public float range = 1;

    // *** PICK UP ***
    // Item (to pickup)
    public GameObject item;

    private RigidbodyConstraints constraints;

    // 
    public GameObject tempParent; 
    public Transform guide;
    public bool enRadio;

    // Is carrying?? 
    bool carrying;

    // *** SUBIR ***
    // player
    private GameObject player;

    // script playercontroller del player
    private PlayerController playerController;

    // altura del game object, para luego asignar la nueva posición al player
    private float miAltura;


    // para ver el range en la escena
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    // Start is called before the first frame update
    void Start()
    {
        // Pickup Init
        item = gameObject;
        constraints = item.GetComponent<Rigidbody>().constraints;
        item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        guide = GameObject.Find("guide").transform;
        tempParent = GameObject.Find("guide");
        item.GetComponent<Rigidbody>().useGravity = true;

        // Subir init
        // guardamos el player con el tag
        player = GameObject.FindGameObjectWithTag("Player");

        // accedemos a su script de playercontroller
        playerController = player.GetComponent<PlayerController>();

        // accedemos a la altura del game object (eje y)
        miAltura = GetComponent<Collider>().bounds.size.y;
    }


    // -------------------------------- EstadosCaja -----------------------------------
    public enum EstadosCaja
    {
        Estatico,
        Dinamico
    }

    private EstadosCaja _estado = EstadosCaja.Dinamico;

    public EstadosCaja Estado
    {
        get => _estado;
        set
        {
            _estado = value;

            // Si es dinámico, podemos desplazarlo
            if (_estado == EstadosCaja.Dinamico)
            {
                // descongelamos los constrains movibles del rigidbody
                gameObject.GetComponent<Rigidbody>().constraints = constraints;
            }

            // Si es estático, no podemos desplazarlo
            else
            {
                // congelamos los contraints del rigidbody (no se puede mover)
                while (transform.position.y < 0.005f)
                {
                    gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                }
            }
        }
    }
    // -------------------------------- EstadosCaja -----------------------------------


    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 0.005f)
        {
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
        // Pickup
        if (carrying == false){
            if (Input.GetKeyDown(KeyCode.E) && (Vector3.Distance(player.transform.position, transform.position) < range) && Math.Abs(player.transform.position.x - transform.position.x) > 0.1f && Math.Abs(player.transform.position.z - transform.position.z) > 0.1f ) {
            pickup();
            carrying = true;
            // cambiamos el estado del player a coger
            //playerController.Estado = PlayerController.EstadosPlayer.Coger;
            }
        }
        else if (carrying == true) {
            if (Input.GetKeyDown(KeyCode.E))
            {
                drop();
                carrying = false;
                // cambiamos el estado del player a soltar
                //playerController.Estado = PlayerController.EstadosPlayer.Soltar;
            }
        }

        // Subir
        // Si el jugador entra en el range del objeto
        if (Vector3.Distance(player.transform.position, transform.position) < range && carrying == false && player.transform.position.y < transform.position.y + miAltura - 0.1f)
        {
            //Debug.Log("Pulse espacio para subirse a la caja");
            enRadio = true;
            // Si está en el range y pulsa espacio
            if (Input.GetKeyDown(KeyCode.Space) | Input.GetKeyDown("joystick button 0"))
            {
                // mandamos la posición y la altura de la caja al otro script
                // el script playercontroller cambiará la posición del player usando estos parámetros
                playerController.posicionTronco = transform.position;
                playerController.alturaTronco = miAltura;

                // cambiamos el estado del player a subir
                playerController.Estado = PlayerController.EstadosPlayer.Subir;
            }

        }
        else {
            enRadio = false;
        }        
    }

    void pickup()
    {
        Estado = EstadosCaja.Dinamico;
        item.GetComponent<Rigidbody>().constraints = constraints;
        item.GetComponent<Rigidbody>().useGravity = false;
        item.GetComponent<Rigidbody>().isKinematic = true;
        item.transform.position = guide.transform.position;
        item.transform.rotation = guide.transform.rotation;
        item.transform.parent = tempParent.transform;

        item.GetComponent<Rigidbody>().constraints = constraints;

        // Activate and and modify player collider
        guide.transform.root.GetComponent<CharacterController>().radius = 0.6f;
        guide.transform.root.GetComponent<CharacterController>().center = new Vector3(0,0.8f,0.2f);

        gameObject.transform.GetChild(0).gameObject.SetActive(false);

    }
    void drop()
    {
        item.GetComponent<Rigidbody>().useGravity = true;
        item.GetComponent<Rigidbody>().isKinematic = false;
        item.transform.parent = null;
        item.transform.position = guide.transform.position;

        // Deactivate and restore default player collider
        guide.transform.root.GetComponent<CharacterController>().radius = 0.3f;
        guide.transform.root.GetComponent<CharacterController>().center = new Vector3(0,0.8f,0);
        Estado = EstadosCaja.Estatico;

        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.4f);
        gameObject.transform.GetChild(0).gameObject.SetActive(true);

    }

}
