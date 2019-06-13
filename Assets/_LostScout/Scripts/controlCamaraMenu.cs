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
            fromGame = false;
            showSeleccionNiveles();
        }
    }

    // Play button
    public void showSeleccionNiveles()
    {
        // First time playing?
        if (PlayerPrefs.GetInt("nivelTutorial") == 0) {
            // Then load tutorial level & set first time to false
            SceneManager.LoadScene("Level Tutorial");
            PlayerPrefs.SetInt("nivelTutorial",1);
        }
        else {
            // Check which default screen to show
            if(fromGame){
                //Debug.Log("menu princiapal");
                canvasMainMenu.transform.Find("Content").GetComponent<Animator>().SetInteger("pos", 0);
            }else{
                //Debug.Log("seleccion");
                canvasMainMenu.transform.Find("Content").GetComponent<Animator>().SetInteger("pos", 1);
            }
        }
    }

    public void showSeleccion1(){
        canvasMainMenu.transform.Find("Content").GetComponent<Animator>().SetInteger("pos", 1);
    }

    public void showSeleccion2(){
        canvasMainMenu.transform.Find("Content").GetComponent<Animator>().SetInteger("pos", 2);
    }

    // Options button
    public void showOpciones (){
        canvasMainMenu.transform.Find("Content").GetComponent<Animator>().SetInteger("pos", -1);
    }

    // Back to menu button
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
