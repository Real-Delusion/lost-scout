using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controlCamaraMenu : MonoBehaviour
{
    public Transform CamTransform;
    public Transform PointTransform;
    public GameObject canvasSeleccionNiveles;
    public GameObject canvasMainMenu;

    void Start(){
        // Hide at start
        canvasMainMenu.GetComponent<Canvas> ().enabled = true;        
        canvasSeleccionNiveles.GetComponent<Canvas> ().enabled = false;
    }
    /* 
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
    }*/

    public void showSeleccionNiveles(){
        canvasMainMenu.GetComponent<Canvas> ().enabled = false;        
        canvasSeleccionNiveles.GetComponent<Canvas> ().enabled = true;
    }
}
