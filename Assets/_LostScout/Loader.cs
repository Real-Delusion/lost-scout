﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public GameObject gameManager;
    void Awake()
    {
        if(GameManager.instance == null){
            Instantiate(gameManager);
            SceneManager.LoadScene("MainMenuScreen");
        }
    }
}
