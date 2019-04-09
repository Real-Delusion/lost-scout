﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPuntuacion : MonoBehaviour
{
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GameManager>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void continueLevel(){
        gameManager.ResumeGame(false);
        gameManager.uiManager.hideMenuPuntuacion();
        SceneManager.LoadScene("MainMenuScreen");
    }
}