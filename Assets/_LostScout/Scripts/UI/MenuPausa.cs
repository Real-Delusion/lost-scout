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
    }

    public void restart(){
        Scene currentScene = SceneManager.GetActiveScene();
        //gameManager.toggleMenuPausa();
        SceneManager.LoadScene(currentScene.name);
    }

    public void settings(){
    }

    public void exit(){
        //uiManager.toggleMenuPausa();
        SceneManager.LoadScene("MainMenuScreen");
    }
}
