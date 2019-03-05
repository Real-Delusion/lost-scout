using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caja : MonoBehaviour
{
    // radio desde el cual se podrá interactuar
    public float radio = 1.5f;

    // constraints del rigidbody
    private RigidbodyConstraints constraints;

    // rigidbody
    private Rigidbody rb;

    // script empujarcaja del player
    private EmpujarCaja empujarScript;

    // player
    private GameObject player;


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

    private EstadosCaja _estado = EstadosCaja.Estatico;

    public EstadosCaja Estado
    {
        get => _estado;
        set
        {
            _estado = value;

            // Si es dinámico
            if (_estado == EstadosCaja.Dinamico)
            {
                // descongelamos los constrains movibles del rigidbody
                rb.constraints = constraints;
            }

            // Si es estático
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
        // es decir, freeze Y y todas las rotaciones
        constraints = rb.constraints;

        // guardamos el player con el tag
        player = GameObject.FindGameObjectWithTag("Player");

        // accedemos a su script de empujarcaja
        empujarScript = player.GetComponent<EmpujarCaja>();
    }

    // Update is called once per frame
    void Update()
    {
        // Si el jugador entra en el radio del objeto
        if (Vector3.Distance(player.transform.position, transform.position) < radio)
        {
            Debug.Log("Mantén pulsado E para empujar la caja");
            if (Input.GetKey(KeyCode.E))
            {
                Estado = EstadosCaja.Dinamico;

                // cambiamos el estado del player a empujando
                empujarScript.Estado = EmpujarCaja.EstadosPlayer.Empujar;
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

            // cambiamos el estado del player a andando
            empujarScript.Estado = EmpujarCaja.EstadosPlayer.Andar;
        }
    }
}
