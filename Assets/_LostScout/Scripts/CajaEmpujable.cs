using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Este script se asigna a un gameobject que el player podrá empujar

public class CajaEmpujable : MonoBehaviour
{
    // radio desde el cual se podrá interactuar
    public float radio = 1.5f;

    // constraints del rigidbody
    private RigidbodyConstraints constraints;

    // rigidbody
    private Rigidbody rb;

    // script playercontroller del player
    private PlayerController playerController;

    // player
    private GameObject player;


    // para ver el radio en la escena
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radio);
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
                rb.constraints = constraints;
            }

            // Si es estático, no podemos desplazarlo
            else
            {
                // congelamos los contraints del rigidbody (no se puede mover)
                rb.constraints = RigidbodyConstraints.FreezeAll;
            }
        }
    }
    // -------------------------------- EstadosCaja -----------------------------------


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // guardamos los constrains movibles del rigidbody
        // es decir, freeze 'Y' y todas las rotaciones
        constraints = rb.constraints;

        // guardamos el player con el tag
        player = GameObject.FindGameObjectWithTag("Player");

        // accedemos a su script de playercontroller
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Si el jugador entra en el radio del objeto
        if (Vector3.Distance(player.transform.position, transform.position) < radio)
        {
            Debug.Log("Mantén pulsado clicl derecho para empujar la caja");
            if (Input.GetKey(KeyCode.Mouse1) && Vector3.Distance(player.transform.position, transform.position) < radio)
            {
                Estado = EstadosCaja.Dinamico;

                // cambiamos el estado del player a empujando
                playerController.Estado = PlayerController.EstadosPlayer.Empujar;
            }
            else
            {
                Estado = EstadosCaja.Estatico;
            }
        }

        // Si está fuera del radio del objeto
        else
        {
            Estado = EstadosCaja.Estatico;
        }

    }
}
