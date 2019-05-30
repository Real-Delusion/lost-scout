using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour
{
    //Palancas y placas de presion
    public GameObject paloPalancaRoca;
    public GameObject paloPalancaCueva;

    public GameObject placaPresionIzq;
    public GameObject placaPresionDcha;

    //Animators
    public Animator animatorRoca;
    public Animator animatorPuerta;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string estadoPalancaCueva = paloPalancaCueva.GetComponent<mecanicaPalanca>().Estado.ToString();
        string estadoPalancaRoca = paloPalancaRoca.GetComponent<mecanicaPalanca>().Estado.ToString();
        string estadoPlacaIzq = placaPresionIzq.GetComponent<PlacaDePresion>().Estado.ToString();
        string estadoPlacaDcha = placaPresionDcha.GetComponent<PlacaDePresion>().Estado.ToString();


        // PALANCA CUEVA
        if (estadoPalancaCueva.Equals("On"))
        {
            //animatorIsla.SetBool("activar", true);
        }

        // PALANCA ROCA
        if (estadoPalancaRoca.Equals("On")) {
            animatorRoca.SetBool("UpDown", true);
        }
        
        // PLACA IZQUIERDA
        if (estadoPlacaIzq.Equals("On")) {
            animatorPuerta.SetFloat("nivelApertura", animatorPuerta.GetFloat("nivelApertura")+1f);
        }
        if (estadoPlacaIzq.Equals("Off")) {
            animatorPuerta.SetFloat("nivelApertura", animatorPuerta.GetFloat("nivelApertura")-1f);
        }
    }
}
