using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlCamaraMenu : MonoBehaviour
{
    public Transform CamTransform;
    public Transform PointTransform;
    public GameObject seleccionadorLv;

    public void moverCamara() {

        
        Animator anim = GetComponent<Animator>();
        anim.SetBool("Zoom", !anim.GetBool("Zoom"));

        if (!anim.GetBool("Zoom"))
        {
            Invoke("delay", 0.8f);
        }
    }

    public void delay()
    {
        seleccionadorLv.SetActive(true);
    }
}
