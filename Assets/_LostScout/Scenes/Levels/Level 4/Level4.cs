using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4 : MonoBehaviour
{
    //Palancas y placas de presion
    public GameObject paloPalancaRoca;
    public GameObject paloPalancaCueva;
    public GameObject troncoOculto;
    public GameObject placaPresionIzq;
    public GameObject placaPresionDcha;

    //Animators
    public Animator animatorRoca;
    public Animator animatorPuerta;
    public Animator animatorTronco;
    private GameObject player;

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

        // PALANCA CUEVA
        if (estadoPalancaCueva.Equals("On"))
        {
            //animatorIsla.SetBool("activar", true);
        }

        // PALANCA ROCA
        if (estadoPalancaRoca.Equals("On")) {
            animatorRoca.SetBool("UpDown", true);
            animatorTronco.SetBool("down", true);
        }
        else {
            animatorRoca.SetBool("UpDown", false);
            animatorTronco.SetBool("down", false);          
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

        // PLAYER
        if (troncoOculto.GetComponent<tronco>().cayendo == true) {
            GameObject troncoPadre = GameObject.FindGameObjectWithTag("troncoPadre");
            troncoPadre.transform.position = troncoOculto.transform.position;
            troncoOculto.transform.SetParent(troncoPadre.transform);
            StartCoroutine(Wait());
            Debug.Log(troncoOculto.transform.position);
        }
    }

    IEnumerator Wait()
    {
        GameObject troncoPadre = GameObject.FindGameObjectWithTag("troncoPadre");
        yield return new WaitForSeconds(0.2f);
        troncoPadre.transform.position = new Vector3(troncoPadre.transform.position.x, 0.0000f, troncoPadre.transform.position.z);
    }
}
