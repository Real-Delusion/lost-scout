using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptLvElevaciones : MonoBehaviour
{

    //Palancas
    public GameObject palanca1;
    public GameObject palanca2;
    public GameObject palanca3;
    public GameObject palanca4;

    //Animators
    public Animator v1;
    public Animator v2;
    public Animator v3;
    public Animator v4;
    public Animator v5;
    public Animator v6;
    public Animator v7;
    public Animator v8;
    public Animator v9;

    //Estados
    float lv0 = 0;
    float lv1 = 0.3f;
    float lv2 = 0.6f;
    float lv3 = 1f;
    EstadoPlataforma estadoActual;

    // Maquinas de estados finitos
    public enum EstadoPlataforma
    {
        opt0, // estado opt0
        opt1, // estado opt1
        opt2, // estado opt2
        opt3, // estado opt3
        opt4, // estado opt4
        opt5, // estado opt5
        opt6, // estado opt6
        opt7, // estado opt7
    }

    private EstadoPlataforma _estadoP = EstadoPlataforma.opt0; // estado de la islas

    // especificación de que hara la palanca dependiendo en el estado en el que este ON / OFF
    public EstadoPlataforma Estado
    {
        get => _estadoP;
        set
        {
            _estadoP = value;

            if (_estadoP == EstadoPlataforma.opt0)
            {
                //v1
                v1.SetFloat("ControlerAnimElev", lv0);
                //v2
                v2.SetFloat("ControlerAnimElev", lv0);
                //v3
                v3.SetFloat("ControlerAnimElev", lv0);
                //v4
                v4.SetFloat("ControlerAnimElev", lv2);
                //v5
                v5.SetFloat("ControlerAnimElev", lv1);
                //v6
                v6.SetFloat("ControlerAnimElev", lv1);
                //v7
                v7.SetFloat("ControlerAnimElev", lv2); 
                //v8
                v8.SetFloat("ControlerAnimElev", lv2);
                //v9
                v9.SetFloat("ControlerAnimElev", lv3);
            }


            if (_estadoP == EstadoPlataforma.opt1)
            {
                //v1
                v1.SetFloat("ControlerAnimElev", lv0);
                //v2
                v2.SetFloat("ControlerAnimElev", lv1);
                //v3
                v3.SetFloat("ControlerAnimElev", lv2);
                //v4
                v4.SetFloat("ControlerAnimElev", lv1);
                //v5
                v5.SetFloat("ControlerAnimElev", lv2);
                //v6
                v6.SetFloat("ControlerAnimElev", lv1);
                //v7
                v7.SetFloat("ControlerAnimElev", lv2);
                //v8
                v8.SetFloat("ControlerAnimElev", lv1);
                //v9
                v9.SetFloat("ControlerAnimElev", lv0);
            }


            if (_estadoP == EstadoPlataforma.opt2)
            {
                //v1
                v1.SetFloat("ControlerAnimElev", lv1);
                //v2
                v2.SetFloat("ControlerAnimElev", lv1);
                //v3
                v3.SetFloat("ControlerAnimElev", lv0);
                //v4
                v4.SetFloat("ControlerAnimElev", lv0);
                //v5
                v5.SetFloat("ControlerAnimElev", lv0);
                //v6
                v6.SetFloat("ControlerAnimElev", lv0);
                //v7
                v7.SetFloat("ControlerAnimElev", lv0);
                //v8
                v8.SetFloat("ControlerAnimElev", lv3);
                //v9
                v9.SetFloat("ControlerAnimElev", lv3);
            }

            if (_estadoP == EstadoPlataforma.opt3)
            {
                //v1
                v1.SetFloat("ControlerAnimElev", lv1);
                //v2
                v2.SetFloat("ControlerAnimElev", lv0);
                //v3
                v3.SetFloat("ControlerAnimElev", lv1);
                //v4
                v4.SetFloat("ControlerAnimElev", lv0);
                //v5
                v5.SetFloat("ControlerAnimElev", lv0);
                //v6
                v6.SetFloat("ControlerAnimElev", lv0);
                //v7
                v7.SetFloat("ControlerAnimElev", lv1);
                //v8
                v8.SetFloat("ControlerAnimElev", lv0);
                //v9
                v9.SetFloat("ControlerAnimElev", lv1);
            }

            if (_estadoP == EstadoPlataforma.opt4)
            {
                //v1
                v1.SetFloat("ControlerAnimElev", lv2);
                //v2
                v2.SetFloat("ControlerAnimElev", lv2);
                //v3
                v3.SetFloat("ControlerAnimElev", lv0);
                //v4
                v4.SetFloat("ControlerAnimElev", lv0);
                //v5
                v5.SetFloat("ControlerAnimElev", lv0);
                //v6
                v6.SetFloat("ControlerAnimElev", lv2);
                //v7
                v7.SetFloat("ControlerAnimElev", lv0);
                //v8
                v8.SetFloat("ControlerAnimElev", lv0);
                //v9
                v9.SetFloat("ControlerAnimElev", lv2);
            }

            if (_estadoP == EstadoPlataforma.opt5)
            {
                //v1
                v1.SetFloat("ControlerAnimElev", lv0);
                //v2
                v2.SetFloat("ControlerAnimElev", lv1);
                //v3
                v3.SetFloat("ControlerAnimElev", lv0);
                //v4
                v4.SetFloat("ControlerAnimElev", lv0);
                //v5
                v5.SetFloat("ControlerAnimElev", lv0);
                //v6
                v6.SetFloat("ControlerAnimElev", lv0);
                //v7
                v7.SetFloat("ControlerAnimElev", lv1);
                //v8
                v8.SetFloat("ControlerAnimElev", lv1);
                //v9
                v9.SetFloat("ControlerAnimElev", lv1);
            }

            if (_estadoP == EstadoPlataforma.opt6)
            {
                //v1
                v1.SetFloat("ControlerAnimElev", lv0);
                //v2
                v2.SetFloat("ControlerAnimElev", lv0);
                //v3
                v3.SetFloat("ControlerAnimElev", lv0);
                //v4
                v4.SetFloat("ControlerAnimElev", lv0);
                //v5
                v5.SetFloat("ControlerAnimElev", lv1);
                //v6
                v6.SetFloat("ControlerAnimElev", lv1);
                //v7
                v7.SetFloat("ControlerAnimElev", lv2);
                //v8
                v8.SetFloat("ControlerAnimElev", lv2);
                //v9
                v9.SetFloat("ControlerAnimElev", lv0);
            }
            if (_estadoP == EstadoPlataforma.opt7)
            {
                //v1
                v1.SetFloat("ControlerAnimElev", lv1);
                //v2
                v2.SetFloat("ControlerAnimElev", lv1);
                //v3
                v3.SetFloat("ControlerAnimElev", lv0);
                //v4
                v4.SetFloat("ControlerAnimElev", lv2);
                //v5
                v5.SetFloat("ControlerAnimElev", lv2);
                //v6
                v6.SetFloat("ControlerAnimElev", lv2);
                //v7
                v7.SetFloat("ControlerAnimElev", lv3);
                //v8
                v8.SetFloat("ControlerAnimElev", lv3);
                //v9
                v9.SetFloat("ControlerAnimElev", lv3);
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        Estado = EstadoPlataforma.opt0;
        estadoActual = Estado;

        palanca1.GetComponent<mecanicaPalanca>().Estado = mecanicaPalanca.EstadosPalanca.Off;
        palanca2.GetComponent<mecanicaPalanca>().Estado = mecanicaPalanca.EstadosPalanca.Off;
        palanca3.GetComponent<mecanicaPalanca>().Estado = mecanicaPalanca.EstadosPalanca.Off;
        palanca4.GetComponent<mecanicaPalanca>().Estado = mecanicaPalanca.EstadosPalanca.Off;

    }

    // Update is called once per frame
    void Update()
    {
        //Estados
        string estadoPalanca1 = palanca1.GetComponent<mecanicaPalanca>().Estado.ToString();
        string estadoPalanca2 = palanca2.GetComponent<mecanicaPalanca>().Estado.ToString();
        string estadoPalanca3 = palanca3.GetComponent<mecanicaPalanca>().Estado.ToString();
        string estadoPalanca4 = palanca4.GetComponent<mecanicaPalanca>().Estado.ToString();

        if (estadoPalanca1.Equals("Off") && estadoPalanca2.Equals("Off") && estadoPalanca3.Equals("Off") && estadoPalanca4.Equals("Off"))
        {
            Estado = estadoActual;
            Estado = EstadoPlataforma.opt0;

        }
        else if (estadoPalanca1.Equals("On") && estadoPalanca2.Equals("Off") && estadoPalanca3.Equals("Off") && estadoPalanca4.Equals("Off"))
        {

            estadoActual = Estado;
            Estado = EstadoPlataforma.opt1;
            //Debug.Log(Estado.ToString());

        }
        else if (estadoPalanca2.Equals("On") && estadoPalanca1.Equals("Off"))
        {

            estadoActual = Estado;
            Estado = EstadoPlataforma.opt2;
            //Debug.Log(Estado.ToString());

            if (estadoPalanca4.Equals("On"))
            {

                estadoActual = Estado;
                Estado = EstadoPlataforma.opt3;
                //Debug.Log(Estado.ToString());
            }
            if (estadoPalanca3.Equals("On"))
            {

                estadoActual = Estado;
                Estado = EstadoPlataforma.opt4;
                //Debug.Log(Estado.ToString());

                if (estadoPalanca4.Equals("On"))
                {

                    estadoActual = Estado;
                    Estado = EstadoPlataforma.opt3;
                    //Debug.Log(Estado.ToString());
                }

            }
        }
        else if (estadoPalanca3.Equals("On") && estadoPalanca2.Equals("Off"))
        {

            estadoActual = Estado;
            Estado = EstadoPlataforma.opt5;
            //Debug.Log(Estado.ToString());

            if (estadoPalanca4.Equals("On"))
            {

                estadoActual = Estado;
                Estado = EstadoPlataforma.opt3;
                //Debug.Log(Estado.ToString());
            }
            if (estadoPalanca1.Equals("On"))
            {

                estadoActual = Estado;
                Estado = EstadoPlataforma.opt6;
                //Debug.Log(Estado.ToString());
            }
        }
        else if (estadoPalanca1.Equals("On") && estadoPalanca2.Equals("On") && estadoPalanca3.Equals("On"))
        {
            estadoActual = Estado;
            Estado = EstadoPlataforma.opt7;
            //Debug.Log(Estado.ToString());
        }
        else
        {
            Estado = estadoActual;
            //Debug.Log(Estado.ToString());
        }
    }
}
