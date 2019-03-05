using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mecanicaPalanca : MonoBehaviour
{
    private Animator animacionPalanca; //Animacion de la placa de presion

    // Start is called before the first frame update
    void Start()
    {
        animacionPalanca = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Debug.Log("TRIGGER ENTER");
            animacionPalanca.SetBool("OnOff", !animacionPalanca.GetBool("OnOff"));

        }
    }

    //Cuando entre en el collider, animación = true
    public void OnTriggerStay(Collider other)
    {
        
    }
    
}
