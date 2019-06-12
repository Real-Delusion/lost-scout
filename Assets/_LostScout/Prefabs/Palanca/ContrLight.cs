using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContrLight : MonoBehaviour
{
    //Palancas
    public GameObject paloPalanca;
    private Light luz;
    Color red = Color.red;
    Color green = Color.green;

    // Start is called before the first frame update
    void Start()
    {
        luz = this.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        string estadoPalanca = paloPalanca.GetComponent<mecanicaPalanca>().Estado.ToString();

        float t = Mathf.PingPong(Time.time, 1f) / 1f;

        if (estadoPalanca == "On") luz.color = Color.green;
    
        if (estadoPalanca == "Off") luz.color = Color.red;

    }
}
