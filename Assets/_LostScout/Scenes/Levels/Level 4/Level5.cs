﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5 : MonoBehaviour
{
    //Palancas y placas de presion
    public GameObject paloPalanca1;
    public GameObject paloPalanca2;
    public GameObject placaPresion1;
    public GameObject placaPresion2;
    public GameObject placaPresion3;

    //Animators
    public Animator animatorIsla;
    public Animator animatorNube;
    public Animator animatorPuente1; //Puente plataforma
    public Animator animatorPuente2; //Puente rio

    //Colliders
    public GameObject colliderIsla;
    public GameObject colliderPuente1;
    public GameObject colliderPuente2;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        string estadoPalanca1 = paloPalanca1.GetComponent<mecanicaPalanca>().Estado.ToString();
        string estadoPalanca2 = paloPalanca2.GetComponent<mecanicaPalanca>().Estado.ToString();
        string estadoPresion1 = placaPresion1.GetComponent<PlacaDePresion>().Estado.ToString();
        string estadoPresion2 = placaPresion2.GetComponent<PlacaDePresion>().Estado.ToString();
        string estadoPresion3 = placaPresion3.GetComponent<PlacaDePresion>().Estado.ToString();

        if (estadoPresion1.Equals("On"))
        {
            animatorIsla.SetBool("activar", true);
        }
        if(estadoPresion1.Equals("Off"))
        {
            animatorIsla.SetBool("activar", false);
        }

        if (estadoPresion3.Equals("On"))
        {
            //bajo la nube un nivel
            animatorNube.SetFloat("valor", 1);
        }
        else
        {
            animatorNube.SetFloat("valor", 0);
        }

        if (estadoPresion1.Equals("On") && estadoPresion3.Equals("On"))
        {
            if (estadoPalanca2.Equals("On"))
            {
                animatorNube.SetFloat("valor", 2);
            }
        }
       

        if (estadoPalanca1.Equals("On"))
        {
            animatorPuente1.SetBool("UpDown", true);
            colliderPuente1.GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            animatorPuente1.SetBool("UpDown", false);
            colliderPuente1.GetComponent<BoxCollider>().enabled = true;
        }

        if (estadoPalanca2.Equals("On"))
        {
            //Quitar puente del rio
            animatorPuente2.SetFloat("valor", 0);
            colliderPuente2.GetComponent<BoxCollider>().enabled = true;

            //Quitar puente de la plataforma
            animatorPuente1.SetBool("UpDown", false);
            colliderPuente1.GetComponent<BoxCollider>().enabled = true;

            if (estadoPresion2.Equals("On"))
            {
                animatorPuente2.SetFloat("valor", 1);
                colliderPuente2.GetComponent<BoxCollider>().enabled = false;
            }
        }

        if (estadoPalanca2.Equals("Off"))
        {
            animatorPuente2.SetFloat("valor", 1);
            colliderPuente2.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
