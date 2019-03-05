using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacaDePresion : MonoBehaviour
{
    private Animator animacionPlaca; //Animacion de la placa de presion
    public Animator animacionPlataforma; //Hay que asignarle el animator de la plataforma que queremos que se mueva

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Empieza");
        animacionPlaca = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Cuando entre en el collider, animación = true
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("TRIGGER ENTER");
        //Animación bajar la placa de presión y subir la plataforma
        animacionPlaca.SetBool("bajarPlaca", !animacionPlaca.GetBool("bajarPlaca"));
        animacionPlataforma.SetBool("subirPlataforma",!animacionPlataforma.GetBool("subirPlataforma"));
    }
    //Cuando salga del collider,animación = false
    public void OnTriggerExit(Collider other)
    {
        Debug.Log("TRIGGER EXIT");
        //Animación subir la placa de presión y bajar la plataforma
        animacionPlaca.SetBool("bajarPlaca", !animacionPlaca.GetBool("bajarPlaca"));
        animacionPlataforma.SetBool("subirPlataforma",!animacionPlataforma.GetBool("subirPlataforma"));
    }
}
