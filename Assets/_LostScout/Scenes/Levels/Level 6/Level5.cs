using System.Collections;
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
        //Estados
        string estadoPalanca1 = paloPalanca1.GetComponent<mecanicaPalanca>().Estado.ToString();
        string estadoPalanca2 = paloPalanca2.GetComponent<mecanicaPalanca>().Estado.ToString();
        string estadoPresion1 = placaPresion1.GetComponent<PlacaDePresion>().Estado.ToString();
        string estadoPresion2 = placaPresion2.GetComponent<PlacaDePresion>().Estado.ToString();
        string estadoPresion3 = placaPresion3.GetComponent<PlacaDePresion>().Estado.ToString();

        //PLACA PRESION 1
        if (estadoPresion1.Equals("On"))
        {
            animatorIsla.SetBool("activar", true);
        }
        if (estadoPresion1.Equals("Off"))
        {
            animatorIsla.SetBool("activar", false);
        }

        //PLACA PRESION 3
        if (estadoPresion3.Equals("On") && estadoPalanca2.Equals("Off"))
        {
            //bajo la nube un nivel
            animatorNube.SetFloat("valor", 1);
        }
        else
        {
            animatorNube.SetFloat("valor", 0);
        }

        //PLACA PRESION 1 Y 3
        if (estadoPresion1.Equals("On") && estadoPresion3.Equals("On"))
        {
            //PALANCA 2
            if (estadoPalanca2.Equals("On"))
            {
                animatorNube.SetFloat("valor", 2);
            }
        }

        //PLACA PRESION 1 Y PALANCA 2
        if (estadoPresion1.Equals("On") && estadoPalanca2.Equals("On"))
        {
            //PLACA PRESION 3
            if (estadoPresion3.Equals("On"))
            {
                animatorNube.SetFloat("valor", 2);
            }
        }

        //PALANCA 1
        if (estadoPalanca1.Equals("On"))
        {
            animatorPuente2.SetBool("UpDown", true);
            colliderPuente2.GetComponent<BoxCollider>().enabled = false;
        }
        if (estadoPalanca1.Equals("Off"))
        {
            animatorPuente2.SetBool("UpDown", false);
            colliderPuente2.GetComponent<BoxCollider>().enabled = true;
        }

        //PALANCA 2
        if (estadoPalanca2.Equals("On"))
        {
            //Animacion nube
            animatorNube.SetFloat("valor", 1);

            //Quitar puente del rio
            animatorPuente1.SetFloat("valor", 0);
            colliderPuente1.GetComponent<BoxCollider>().enabled = true;

            //Quitar puente de la plataforma
            animatorPuente2.SetBool("UpDown", false);
            colliderPuente2.GetComponent<BoxCollider>().enabled = true;

            //PLACA PRESION 2
            if (estadoPresion2.Equals("On"))
            {
                //Quitar puente del rio
                animatorPuente1.SetFloat("valor", 1);
                colliderPuente1.GetComponent<BoxCollider>().enabled = false;
            }

            //PLACA PRESION 1 Y 3
            if (estadoPresion1.Equals("On") && estadoPresion3.Equals("On"))
            {

                animatorNube.SetFloat("valor", 2);

            }

            //PALANCA 1
            if (estadoPalanca1.Equals("Off"))
            {
                animatorPuente2.SetBool("UpDown", true);
                colliderPuente2.GetComponent<BoxCollider>().enabled = false;
            }
            if (estadoPalanca1.Equals("On"))
            {
                animatorPuente2.SetBool("UpDown", false);
                colliderPuente2.GetComponent<BoxCollider>().enabled = true;
            }
        }
        if (estadoPalanca2.Equals("Off"))
        {
            animatorPuente1.SetFloat("valor", 1);
            colliderPuente1.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
