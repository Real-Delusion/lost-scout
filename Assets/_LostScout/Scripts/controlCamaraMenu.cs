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
    public bool fromGame = false;


    void Start()
    {
        // Hide at start
        if (fromGame)
        {
            showSeleccionNiveles();
        }
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

    public void showSeleccionNiveles()
    {
        if (PlayerPrefs.GetInt("nivelTutorial") == 0) {
            SceneManager.LoadScene("Level Tutorial");
            PlayerPrefs.SetInt("nivelTutorial",1);
        }
        else {
            if(fromGame){
                canvasMainMenu.transform.Find("Content").GetComponent<Animator>().SetBool("animated", false);
            }else{
                canvasMainMenu.transform.Find("Content").GetComponent<Animator>().SetBool("animated", true);                
            }
            canvasMainMenu.transform.Find("Content").GetComponent<Animator>().SetInteger("pos", 1);
        }
    }

    public void volver()
    {
        canvasMainMenu.transform.Find("Content").GetComponent<Animator>().SetBool("animated", true);
        canvasMainMenu.transform.Find("Content").GetComponent<Animator>().SetInteger("pos", 0);
    }

    public void exit()
    {
        Application.Quit();
    }
}
