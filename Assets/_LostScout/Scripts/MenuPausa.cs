using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuPausa : MonoBehaviour
{
    public GameManager gameManager;

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

    public void exit(){
        gameManager.ResumeGame(true);
        gameManager.fromGame = true;
        GameManager.sceneTransitions.load("MainMenuScreen");
    }
}
