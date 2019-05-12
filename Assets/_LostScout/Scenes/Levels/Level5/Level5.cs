using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5 : MonoBehaviour
{
    public GameObject paloPalanca;
    public GameObject placaPresion1;
    public GameObject placaPresion2;
    public GameObject placaPresion3;
    public Animator animatorNube;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        string estadoPalanca = paloPalanca.GetComponent<mecanicaPalanca>().Estado.ToString();
        string estadoPresion1 = placaPresion1.GetComponent<PlacaDePresion>().Estado.ToString();
        string estadoPresion2 = placaPresion1.GetComponent<PlacaDePresion>().Estado.ToString();
        string estadoPresion3 = placaPresion1.GetComponent<PlacaDePresion>().Estado.ToString();

        print(estadoPresion2);

        if (estadoPresion1.Equals("On"))
        {
            animatorNube.SetFloat("valor", 1);

            /*if (estadoPresion2.Equals("On"))
            {
                animatorNube.SetFloat("valor", 2);
            }*/
        }
        else
        {
            animatorNube.SetFloat("valor", 0);

        }
    }
}
