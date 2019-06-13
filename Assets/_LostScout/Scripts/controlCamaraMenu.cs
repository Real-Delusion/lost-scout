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
    public GameObject canvasExit;


    void Start()
    {
        // Hide at start
        if (fromGame)
        {
            showSeleccionNiveles();
        }
    }

    public void showSeleccionNiveles()
    {
        if (PlayerPrefs.GetInt("nivelTutorial") == 0) {
            SceneManager.LoadScene("Level Tutorial");
            PlayerPrefs.SetInt("nivelTutorial",1);
        }
        else {
            if(fromGame){
                canvasMainMenu.transform.Find("Content").GetComponent<Animator>().SetInteger("pos", 0);
            }else{
                canvasMainMenu.transform.Find("Content").GetComponent<Animator>().SetInteger("pos", 1);
            }
        }
    }

    public void showOpciones (){
        canvasMainMenu.transform.Find("Content").GetComponent<Animator>().SetInteger("pos", -1);
    }

    public void volver()
    {
        canvasMainMenu.transform.Find("Content").GetComponent<Animator>().SetInteger("pos", 0);
    }

    public void openConfirmationWindow()
    {
        canvasExit.transform.Find("ModalContent").GetComponent<Animator>().SetBool("open", true);
    }

    public void closeConfirmationWindow()
    {
        canvasExit.transform.Find("ModalContent").GetComponent<Animator>().SetBool("open", false);
    }

    public void exit()
    {
        Application.Quit();
    }
}
