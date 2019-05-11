﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour
{
    public GameObject menuPausa;
    public GameObject menuPuntuacion;
    public GameObject insigniaHabilidad;
    public GameObject insigniaPrestigio;
    public GameObject insigniaObsequio;
    public float _fadeSpeed = 5f;
    public GameObject bienHecho;
    public Text tiempo;
    public Text tiempoRecord;
    public GameObject luzChapa1;
    public GameObject luzChapa2;
    public GameObject luzChapa3;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void toggleMenuPausa(bool state){
        menuPausa.transform.Find("ModalContent").gameObject.GetComponent<Animator>().SetBool("open", state);
    }

    public void showMenuPuntuacion (int insignias, float time){
        // Return all insignias to their default state (size 0) 
        menuPuntuacion.transform.Find("ModalContent").Find("obsequio").gameObject.GetComponent<Animator>().SetBool("show", false);
        menuPuntuacion.transform.Find("ModalContent").Find("habilidad").gameObject.GetComponent<Animator>().SetBool("show", false);
        menuPuntuacion.transform.Find("ModalContent").Find("prestigio").gameObject.GetComponent<Animator>().SetBool("show", false);

        menuPuntuacion.transform.Find("ModalContent").gameObject.GetComponent<Animator>().SetBool("open", true);
        tiempo.text = (Math.Round(time,2).ToString())+" s";
        insigniaObsequio.SetActive(true);
        StartCoroutine(MyCoroutine("obsequio"));

        if(insignias >= 2){
            StartCoroutine(MyCoroutine2("habilidad"));
            insigniaHabilidad.SetActive(true);
        }else{
            insigniaHabilidad.SetActive(false); 
        }
        if(insignias >= 3){
            StartCoroutine(MyCoroutine3("prestigio"));
            insigniaPrestigio.SetActive(true);
        }else{
            insigniaPrestigio.SetActive(false);
        }
    }

    public void animarChapa (string chapa) {
        if (chapa == "obsequio") {
            luzChapa1.gameObject.SetActive(false);
            luzChapa1.gameObject.SetActive(true);
        }
        else if (chapa == "habilidad") {
            luzChapa2.gameObject.SetActive(false);
            luzChapa2.gameObject.SetActive(true);
        }
        else if (chapa == "prestigio") {
            luzChapa3.gameObject.SetActive(false);
            luzChapa3.gameObject.SetActive(true);
        }
        menuPuntuacion.transform.Find("ModalContent").Find(chapa).gameObject.GetComponent<Animator>().SetBool("show", true);
    }

    IEnumerator MyCoroutine(string chapa)
    {   
        yield return new WaitForSecondsRealtime(0.5f);
        animarChapa(chapa);
    }

    IEnumerator MyCoroutine2(string chapa)
    {   
        yield return new WaitForSecondsRealtime(1f);
        animarChapa(chapa);
    }

    IEnumerator MyCoroutine3(string chapa)
    {   
        yield return new WaitForSecondsRealtime(1.5f);
        animarChapa(chapa);
    }

    public void hideMenuPuntuacion (){
        menuPuntuacion.transform.Find("ModalContent").gameObject.GetComponent<Animator>().SetBool("open", false);
    }
    public void showBienHecho()
    {
        StartCoroutine(Wait1());
        bienHecho.transform.Find("ModalContent").gameObject.GetComponent<Animator>().SetBool("open", true);

    }
    public void hideBienHecho()
    {
        bienHecho.transform.Find("ModalContent").gameObject.GetComponent<Animator>().SetBool("open", false);
    }
    IEnumerator Wait1()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        // Show menu puntuacion (pass insignias and time)
        Camera.main.transform.GetChild(0).gameObject.SetActive(true);
        Camera.main.transform.GetChild(1).gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(0.5f);
        Camera.main.transform.GetChild(2).gameObject.SetActive(true);
        Camera.main.transform.GetChild(3).gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(2f);
        Camera.main.transform.GetChild(0).gameObject.SetActive(false);
        Camera.main.transform.GetChild(1).gameObject.SetActive(false);
        yield return new WaitForSecondsRealtime(2);
        Camera.main.transform.GetChild(2).gameObject.SetActive(false);
        Camera.main.transform.GetChild(3).gameObject.SetActive(false);
    }

}
