using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controlCamaraMenu : MonoBehaviour
{
    public Transform CamTransform;
    public Transform PointTransform;
    public GameObject seleccionadorLv;

    void Start(){
        // Hide at start
        seleccionadorLv.GetComponent<Canvas> ().enabled = false;
    }
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
        //SceneManager.LoadScene("SeleccionNivel");
        //seleccionadorLv.SetActive(true);
        // Show
        seleccionadorLv.GetComponent<Canvas> ().enabled = true;
    }
}
