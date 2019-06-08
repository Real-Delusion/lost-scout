using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour
{
    public GameObject menuPausa;
    public GameObject menuPuntuacion;
    public GameObject hud;
    public GameObject insigniaHabilidad;
    public GameObject insigniaPrestigio;
    public GameObject insigniaObsequio;
    public float _fadeSpeed = 5f;
    public GameObject bienHecho;
    public GameObject levelName;
    public Text textLevelName;
    public Text textLevelNameSombra;
    public Text tiempo;
    public Text tiempoRecord;
    public Text tiempoHud;
    public GameObject luzChapa1;
    public GameObject luzChapa2;
    public GameObject luzChapa3;
    private GameObject confettiCamera;


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

    public void toggleHUD (bool state) {
        hud.SetActive(state);
    }
    public void printTime (float time, bool isPaused) {
        if (!isPaused) tiempoHud.text = (Math.Round(time,0).ToString())+" ''";
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
            luzChapa1.GetComponent<AudioSource>().Play();
        }
        else if (chapa == "habilidad") {
            luzChapa2.gameObject.SetActive(false);
            luzChapa2.gameObject.SetActive(true);
            luzChapa2.GetComponent<AudioSource>().Play();
        }
        else if (chapa == "prestigio") {
            luzChapa3.gameObject.SetActive(false);
            luzChapa3.gameObject.SetActive(true);
            luzChapa3.GetComponent<AudioSource>().Play();
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
        bienHecho.GetComponent<Canvas>().enabled = true;
        confettiCamera = GameObject.FindWithTag("confeti");
        StartCoroutine(Wait1());
        bienHecho.transform.Find("ModalContent").gameObject.GetComponent<Animator>().SetBool("open", true);
        Camera.main.depth = -1; 
    }
    public void hideBienHecho()
    {
        bienHecho.transform.Find("ModalContent").gameObject.GetComponent<Animator>().SetBool("open", false);
    }

    public void showLevelName(string level)
    {
        levelName = GameObject.Find("NombreNivel");
        textLevelName = (Text) levelName.transform.GetChild(0).GetChild(3).GetComponent<Text>();
        textLevelNameSombra = (Text) levelName.transform.GetChild(0).GetChild(2).GetComponent<Text>();

        levelName.GetComponent<Canvas>().enabled = true;

        textLevelName.GetComponent<Text>().text = level;
        textLevelNameSombra.GetComponent<Text>().text = level;

        levelName.transform.Find("ModalContent").gameObject.GetComponent<Animator>().Play("nombreNivel", -1, 0);
        Camera.main.depth = -1;
    }
    public void hideLevelName()
    {
        //levelName.transform.Find("ModalContent").gameObject.GetComponent<Animator>().SetBool("open", false);
        //levelName.transform.Find("ModalContent").gameObject.GetComponent<Animator>().enabled = false;
        levelName.GetComponent<Canvas>().enabled = false;
    }

    IEnumerator Wait1()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        // Show menu puntuacion (pass insignias and time)
        bienHecho.GetComponent<AudioSource>().Play();
        confettiCamera.transform.GetChild(0).gameObject.SetActive(true);
        confettiCamera.transform.GetChild(1).gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(0.5f);
        confettiCamera.transform.GetChild(2).gameObject.SetActive(true);
        confettiCamera.transform.GetChild(3).gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(2f);
        confettiCamera.transform.GetChild(0).gameObject.SetActive(false);
        confettiCamera.transform.GetChild(1).gameObject.SetActive(false);
        yield return new WaitForSecondsRealtime(2);
        confettiCamera.transform.GetChild(2).gameObject.SetActive(false);
        confettiCamera.transform.GetChild(3).gameObject.SetActive(false);
    }

}
