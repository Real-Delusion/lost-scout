using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level6 : MonoBehaviour
{
    //PALANCAS
    public GameObject palanca1;
    public GameObject palanca2;
    public GameObject palanca3;

    //PLACAS DE PRESION
    public GameObject placaPresion1;
    public GameObject placaPresion2;

    //ANIMATORS
    public Animator animatorPuertaA1; //Grupo troncos 1
    /*public Animator animatorPuertaA2; //Puerta cueva 1
    public Animator animatorPuertaB1; //Grupo troncos 2
    public Animator animatorPuenteB2; //Puerta cueva 2*/


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Estados
        string estadoPalanca1 = palanca1.GetComponent<mecanicaPalanca>().Estado.ToString();
        string estadoPalanca2 = palanca2.GetComponent<mecanicaPalanca>().Estado.ToString();
        string estadoPalanca3 = palanca3.GetComponent<mecanicaPalanca>().Estado.ToString();
        string estadoPresion1 = placaPresion1.GetComponent<PlacaDePresion>().Estado.ToString();
        string estadoPresion2 = placaPresion2.GetComponent<PlacaDePresion>().Estado.ToString();

        if (estadoPalanca1.Equals("On"))
        {
            animatorPuertaA1.SetBool("open", true);
        }
        else
        {
            animatorPuertaA1.SetBool("open", false);
        }

    }
}
