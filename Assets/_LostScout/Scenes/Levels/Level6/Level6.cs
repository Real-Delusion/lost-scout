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
    public Animator animatorPuertaA2; //Puerta cueva 1
    public Animator animatorPuertaB1; //Grupo troncos 2
    public Animator animatorPuertaB2; //Puerta cueva 2
    public Animator animatorPlacaPresion1; //Placa presion 1
    public Animator animatorPlacaPresion2; //Placa presion 2

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

        //--------------- PARTE 1 -------------------

        //PALANCA 1 ON
        if (estadoPalanca1.Equals("On"))
        {
            animatorPuertaA1.SetBool("open", true);
            animatorPuertaA2.SetBool("open", true);

            //PALANCA 2
            if (estadoPalanca2.Equals("Off"))
            {
                animatorPuertaB2.SetBool("open", false);

                //PLACA PRESION 1
                if (estadoPresion1.Equals("Off"))
                {
                    animatorPlacaPresion1.SetBool("show", false);
                }
            }

        }
        //PALANCA 1 OFF
        if (estadoPalanca1.Equals("Off"))
        {
            animatorPuertaA1.SetBool("open", false);
            animatorPuertaA2.SetBool("open", false);
        }

        //PALANCA 2 ON
        if (estadoPalanca2.Equals("On"))
        {
            animatorPuertaA2.SetBool("open", false);
            animatorPuertaB2.SetBool("open", true);
            animatorPlacaPresion1.SetBool("show", true);

            //PALANCA 1 OFF
            if (estadoPalanca1.Equals("Off"))
            {
                animatorPuertaA1.SetBool("open", false);
                animatorPuertaA2.SetBool("open", false);
            }
        }

        //PLACA PRESION 1 ON
        if (estadoPresion1.Equals("On"))
        {
            animatorPuertaB2.SetBool("open", true);

            //PALANCA 2
            if (estadoPalanca2.Equals("Off"))
            {
                animatorPuertaA2.SetBool("open", true);

                //PALANCA 3
                if (estadoPalanca3.Equals("Off"))
                {
                    animatorPuertaA1.SetBool("open", true);
                    animatorPuertaB1.SetBool("open", false);
                }
            }
        }

        //--------------- PARTE 2 -------------------
        //PALANCA 3 ON
        if (estadoPalanca3.Equals("On"))
        {
            animatorPuertaA1.SetBool("open", false);
            animatorPuertaB1.SetBool("open", true);
            animatorPlacaPresion2.SetBool("show", true);


            //PALANCA 1 OFF
            if (estadoPalanca1.Equals("Off"))
            {
                animatorPuertaA1.SetBool("open", false);
                animatorPuertaA2.SetBool("open", false);
            }

            //PALANCA 2 OFF
            if (estadoPalanca2.Equals("Off"))
            {
                animatorPuertaB2.SetBool("open", false);
            }

            //PLACA PRESION 1 ON
            if (estadoPresion1.Equals("On"))
            {
                animatorPuertaB2.SetBool("open", true);
            }
        }

        //PLACA PRESION 2 ON
        if (estadoPresion2.Equals("On"))
        {
            //PALANCA 3 OFF
            if (estadoPalanca3.Equals("Off"))
            {
                animatorPuertaB1.SetBool("open", true);
            }
        }
        //PLACA PRESION 2 OFF
        if (estadoPresion2.Equals("Off"))
        {
            //PALANCA 3 OFF
            if (estadoPalanca3.Equals("Off"))
            {
                animatorPuertaB1.SetBool("open", false);
                animatorPlacaPresion2.SetBool("show", false);
            }
        }









        }
}
