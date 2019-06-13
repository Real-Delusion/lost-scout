using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuPausa : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject modalExit;
    public GameObject menuOpts;
    public GameObject menuPausa;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameManager = GetComponent<GameManager>();
    }

    public void resume(){
        gameManager.ResumeGame(true);
    }

    public void restart(){
        Scene currentScene = SceneManager.GetActiveScene();
        gameManager.ResumeGame(true);
        SceneManager.LoadScene(currentScene.name);
    }

    public void settings(){
    }

    public void openConfirmationWindow()
    {
        modalExit.GetComponent<Animator>().SetBool("open", true);
    }

    public void closeConfirmationWindow()
    {
        modalExit.GetComponent<Animator>().SetBool("open", false);
    }

    public void openMenuOpts()
    {
        menuPausa.GetComponent<Animator>().SetBool("open", false);
        menuOpts.GetComponent<Animator>().SetBool("open", true);
    }

    public void closemenuOpts()
    {
        menuPausa.GetComponent<Animator>().SetBool("open", true);
        menuOpts.GetComponent<Animator>().SetBool("open", false);
    }

    public void exit(){
        modalExit.GetComponent<Animator>().SetBool("open", false);
        gameManager.ResumeGame(true);
        gameManager.fromGame = true;
        if(GameManager.sceneTransitions != null){
            GameManager.sceneTransitions.load("MainMenuScreen");
        }
    }
}
