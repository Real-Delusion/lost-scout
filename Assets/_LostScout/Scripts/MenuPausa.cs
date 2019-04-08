﻿using System.Collections;
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
        gameManager.ResumeGame();
    }

    public void restart(){
        Scene currentScene = SceneManager.GetActiveScene();
        gameManager.enableInput(true);
        gameManager.gamePaused = false;
        gameManager.uiManager.toggleMenuPausa();
        SceneManager.LoadScene(currentScene.name);
    }

    public void settings(){
    }

    public void exit(){
        gameManager.uiManager.toggleMenuPausa();
        SceneManager.LoadScene("MainMenuScreen");
    }
}