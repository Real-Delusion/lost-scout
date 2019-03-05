using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ESTE SCRIPT SE COMBINARÁ CON EL SCRIPT DEL PLAYER
public class EmpujarCaja : MonoBehaviour
{
    public float velocidad = 10f;

    private Rigidbody rb;

    // -------------------------------- EstadosPlayer -----------------------------------
    public enum EstadosPlayer
    {
        Andar,
        Empujar
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
                // aquí añadir animación de empujar del personaje
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
    {
        // movimiento para comprobar que funciona el script de la caja
        Vector3 movimiento = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.Translate(movimiento * (Time.deltaTime * velocidad));
    }
}
