using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacaDePresion : MonoBehaviour
{
    private Animator animacionPlaca; //Animacion de la placa de presion
    public Animator animacionPlataforma; //Hay que asignarle el animator de la plataforma que queremos que se mueva
    public GameObject colliderPuente;

    public enum EstadosPlaca
    {
        On,

        Off
    }

    private EstadosPlaca _estado = EstadosPlaca.Off;

    public EstadosPlaca Estado
    {
        get => _estado;
        set
        {
            _estado = value;
            if (_estado == EstadosPlaca.On)
            {
                //Animación bajar la placa de presión y subir la plataforma
                animacionPlaca.SetBool("bajarPlaca", !animacionPlaca.GetBool("bajarPlaca"));
                animacionPlataforma.SetBool("subirPlataforma", !animacionPlataforma.GetBool("subirPlataforma"));
                if (colliderPuente != null) colliderPuente.SetActive(false);//Desactivar el collider para que pueda pasar
            }

            else if(_estado == EstadosPlaca.Off)
            {
                //Animación subir la placa de presión y bajar la plataforma
                animacionPlaca.SetBool("bajarPlaca", !animacionPlaca.GetBool("bajarPlaca"));
                animacionPlataforma.SetBool("subirPlataforma", !animacionPlataforma.GetBool("subirPlataforma"));
                if (colliderPuente != null) colliderPuente.SetActive(true); //Activar el collider para que no pueda pasar
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Buscar animación de la placa
        animacionPlaca = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Cuando entre en el collider, animación = true
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" || other.tag == "TroncoEmpujar")
        {
            if (!Estado.Equals("On"))
            {
                Estado = EstadosPlaca.On;
            }
        }
      
    }

    //Cuando salga del collider,animación = false
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" || other.tag == "TroncoEmpujar") {

            if (!Estado.Equals("Off"))
            {
                Estado = EstadosPlaca.Off;
            }

        }

    }
}
