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
        string estadoPalanca4 = palanca4.GetComponent<mecanicaPalanca>().Estado.ToString();
    }
}
