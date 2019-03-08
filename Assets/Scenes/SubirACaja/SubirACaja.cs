using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubirACaja : MonoBehaviour
{
    private Rigidbody rb;
    public Vector3 posicionTronco;
    public float alturaTronco;

    private Vector3 posicion;

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

                Vector3 nuevaPosicion = new Vector3(posicionTronco.x, posicionTronco.y + alturaTronco, posicionTronco.z);
                Debug.Log("nueva = " + nuevaPosicion);

                posicion = nuevaPosicion;
                this.transform.localPosition = nuevaPosicion;
            }
        }
    }
    // -------------------------------- EstadosPlayer -----------------------------------

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        posicion = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.localPosition);
        //transform.localPosition = posicion;

        transform.localPosition = new Vector3(4, 4, 4);
    }
}
