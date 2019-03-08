using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaParaSubir : MonoBehaviour
{
    // radio desde el cual se podrá interactuar
    public float radio = 1.5f;

    // player
    private GameObject player;

    // script playercontroller del player
    private PlayerController playerController;

    private float miAltura;

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radio);
    }

    // Start is called before the first frame update
    void Start()
    {
        // guardamos el player con el tag
        player = GameObject.FindGameObjectWithTag("Player");

        // accedemos a su script de playercontroller
        playerController = player.GetComponent<PlayerController>();

        // accedemos a la altura del game object (eje y)
        miAltura = GetComponent<Collider>().bounds.size.y;

    }

    // Update is called once per frame
    void Update()
    {
        // Si el jugador entra en el radio del objeto
        if (Vector3.Distance(player.transform.position, transform.position) < radio)
        {
            //Debug.Log("Pulse E para subirse a la caja");
            if (Input.GetKeyDown(KeyCode.E))
            {
                // mandamos la posición y la altura de la caja al otro script
                playerController.posicionTronco = transform.position;
                playerController.alturaTronco = miAltura;

                // cambiamos el estado del player a empujando
                playerController.Estado = PlayerController.EstadosPlayer.Subir;
            }

        }

        // Si está fuera del radio del objeto
        else
        {
            // cambiamos el estado del player a andando
            playerController.Estado = PlayerController.EstadosPlayer.Andar;
        }
    }
}
