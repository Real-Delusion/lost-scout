using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubirACaja : MonoBehaviour
{
    private Rigidbody rb;

    // -------------------------------- EstadosPlayer -----------------------------------
    public enum EstadosPlayer
    {
        Andar,
        Empujar,
        Subir
    }

    private EstadosPlayer _estado = EstadosPlayer.Andar;

    public EstadosPlayer Estado
    {
        get => _estado;
        set
        {
            _estado = value;
            if (_estado == EstadosPlayer.Empujar)
            {
                Debug.Log("empujando");
                // aquí añadiremos animación de empujar del personaje
            }

            if (_estado == EstadosPlayer.Subir)
            {
                Debug.Log("Subiendo");
                // aquí añadiremos animación de subir del personaje
            }
        }
    }
    // -------------------------------- EstadosPlayer -----------------------------------

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    { /*
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
        */
    }
}
