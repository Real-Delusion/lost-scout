using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlCamaraMenu : MonoBehaviour
{
    public Transform CamTransform;
    public Transform PointTransform;
    public GameObject seleccionadorLv;
    private Vector3 nuevaPosicion;

    public void moverCamara() {

        //Debug.Log(t.ToString());
        // Cambiamos de posición de forma smooth
        nuevaPosicion = PointTransform.position;
        this.transform.localPosition = nuevaPosicion;
        Animator anim = GetComponent<Animator>();
        anim.SetBool("Zoom", !anim.GetBool("Zoom"));        
    }
}
