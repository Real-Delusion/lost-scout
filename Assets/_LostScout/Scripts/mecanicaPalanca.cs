using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mecanicaPalanca : MonoBehaviour
{
    // animacion de la palanca - estado publico, para que se pueda utilizar desde cualquier scene
    public Animator animacionPalanca;
    // animacion del objeto que active la palanca - estado publico, para que se pueda utilizar desde cualquier scene
    public Animator animObjeto; 
    // radio del area en la que se podrá activar la palanca - estado publico (se puede modificar)
    public float radio = 2f;
    // referencia al player(personaje)
    public Transform player;

    // Maquinas de estados finitos
    public enum EstadosPalanca
    {
        On, // estado activo
        Off, // estado apagado
    }

    private EstadosPalanca _estadoP = EstadosPalanca.Off; // estado de la palanca por defecto --> desactiva

    // especificación de que hara la palanca dependiendo en el estado en el que este ON / OFF
    public EstadosPalanca Estado
    {
        get => _estadoP;
        set
        {
            _estadoP = value;
            // caso en que la palanca este ON/Activa
            if (_estadoP == EstadosPalanca.On) 
            {
                animacionPalanca.SetBool("OnOff", true); // Se ejecuta la animación para que se ponga la palanca en posicion activa
                animObjeto.SetBool("UpDown", true); // Se ejecuta la animación del objeto que activa
            }

            // caso en que la palanca este ON/Activa
            if (_estadoP == EstadosPalanca.Off) 
            {
                animacionPalanca.SetBool("OnOff", false); // Se ejecuta la animación para que se ponga la palanca en posicion desactiva
                animObjeto.SetBool("UpDown", false); // Se ejecuta la animacion del objeto para que vuelva a su lugar inicial
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        //animacionPalanca = GetComponent<Animator>(); // caso en que animacion de la palanca sea privado

    }

    // Update is called once per frame
    void Update()
    {
        // comprobacion de los estados de la palanca
        switch (Estado)
        {
            //  caso en que la palanca este desactiva OFF
            case EstadosPalanca.Off: 
                if (Vector3.Distance(transform.position, player.position) < radio) // si el player esta dentro del area de accion 
                {
                    if (Input.GetKeyDown(KeyCode.E)) // si se pulsa la tecla "E" destro del radio
                    {
                        Estado = EstadosPalanca.On; // Se cambia la panca a estado ON / Activo
                    }
                }
                break;

            //  caso en que la palanca este activa ON 
            case EstadosPalanca.On:
                if (Vector3.Distance(transform.position, player.position) < radio) // si el player esta dentro del area de accion 
                {
                    if (Input.GetKeyDown(KeyCode.E)) // si se pulsa la tecla "E" destro del radio
                    {
                        Estado = EstadosPalanca.Off; // Se cambia la panca a estado OFF / Desactiva
                    }
                }
                break;
        }

    }
    
}
