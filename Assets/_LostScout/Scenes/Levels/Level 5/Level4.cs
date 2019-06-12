using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4 : MonoBehaviour
{
    //Palancas y placas de presion
    public GameObject paloPalancaRoca;
    public GameObject paloPalancaCueva;
    public GameObject placaPresionIzq;
    public GameObject placaPresionDcha;
    public GameObject placaPresionCueva;

    //Animators
    public Animator animatorRoca;
    public Animator animatorPuerta;
    public Animator animatorPlaca;
    public Animator animatorEscalera;
    private GameObject player;

    //Pista
    public GameObject hint;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        string estadoPalancaCueva = paloPalancaCueva.GetComponent<mecanicaPalanca>().Estado.ToString();
        string estadoPalancaRoca = paloPalancaRoca.GetComponent<mecanicaPalanca>().Estado.ToString();
        string estadoPlacaIzq = placaPresionIzq.GetComponent<PlacaDePresion>().Estado.ToString();
        string estadoPlacaDcha = placaPresionDcha.GetComponent<PlacaDePresion>().Estado.ToString();
        string estadoPlacaCueva = placaPresionCueva.GetComponent<PlacaDePresion>().Estado.ToString();

        // PALANCA CUEVA
        if (estadoPalancaCueva.Equals("On"))
        {
            //animatorIsla.SetBool("activar", true);
        }

        // PALANCA ROCA
        if (estadoPalancaRoca.Equals("On")) {
            animatorRoca.SetBool("UpDown", true);
            animatorPlaca.SetBool("Hide", true);
        }
        else {
           animatorRoca.SetBool("UpDown", false);
           animatorPlaca.SetBool("Hide", false);          
        }
        
        // PLACA UNA U OTRA
        if (estadoPlacaIzq.Equals("On") || estadoPlacaDcha.Equals("On")) {
            animatorPuerta.SetFloat("nivelApertura", 1);
        }
        else {
            animatorPuerta.SetFloat("nivelApertura", 0);
        }

        // PLACAS AMBAS
        if (estadoPlacaIzq.Equals("On") && estadoPlacaDcha.Equals("On")) {
            animatorPuerta.SetFloat("nivelApertura", 2);
        }

        // PLACA CUEVA
        if (estadoPlacaCueva.Equals("On")) {
            animatorEscalera.SetBool("UpDown", true);
        }
        else {
            animatorEscalera.SetBool("UpDown", false);
        }

        //PISTA
        if (GameObject.Find("GameManager(Clone)").GetComponent<GameManager>().time > 10f)
        {
            hint.GetComponent<Animator>().SetBool("show", true);
        }
    }
}
