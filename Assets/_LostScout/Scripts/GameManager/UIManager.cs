using System.Collections;
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
    public Image obe;
    public float _fadeSpeed = 5f;
    public GameObject bienHecho;
    public Text tiempo;
    public Text tiempoRecord;

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
        menuPuntuacion.transform.Find("ModalContent").gameObject.GetComponent<Animator>().SetBool("open", true);
        tiempo.text = (Math.Round(time,2).ToString())+" s";
        insigniaObsequio.SetActive(true);
        menuPuntuacion.transform.Find("ModalContent").Find("obsequio").gameObject.GetComponent<Animator>().SetBool("show", true);
        //StartCoroutine (Fadein (obe, _fadeSpeed));

        if(insignias >= 2){
            //insigniaHabilidadGrey.SetActive(false);
            insigniaHabilidad.SetActive(true);
            menuPuntuacion.transform.Find("ModalContent").Find("habilidad").gameObject.GetComponent<Animator>().SetBool("show", true);

        }else{
            insigniaHabilidad.SetActive(false); 
        }
        if(insignias >= 3){
            //insigniaPrestigioGrey.SetActive(false);
            insigniaPrestigio.SetActive(true);
            menuPuntuacion.transform.Find("ModalContent").Find("prestigio").gameObject.GetComponent<Animator>().SetBool("show", true);
        }else{
            insigniaPrestigio.SetActive(false);
        }
    }

    // You can use it for multiple images, just pass that image.
    IEnumerator Fadein (Image image, float speed)
    {
        // Will run only until image's alpha becomes completely 255, will stop after that.
        while (image.color.a < 255) {
                        yield return new WaitForSecondsRealtime (0.5f);

        /*    // You can replace WaitForEndOfFrame with WaitForSeconds.
            Color colorWithNewAlpha = image.color;
            //colorWithNewAlpha.a += speed;
            colorWithNewAlpha.a += 20f;
            Debug.Log(obe.color);
            image.color = colorWithNewAlpha;
            //Debug.Log(image.color.a + " " + image); */
            Color imagecolor = image.color;
            imagecolor.a = 255;
            Color colorLerp = Color.Lerp(image.color, imagecolor, Mathf.PingPong(Time.time, 1));
            image.color = colorLerp;
        } 
    }

    public void hideMenuPuntuacion (){
        menuPuntuacion.transform.Find("ModalContent").gameObject.GetComponent<Animator>().SetBool("open", false);
    }
    public void showBienHecho()
    {
        StartCoroutine(Wait());
        bienHecho.transform.Find("ModalContent").gameObject.GetComponent<Animator>().SetBool("open", true);

    }
    public void hideBienHecho()
    {
        bienHecho.transform.Find("ModalContent").gameObject.GetComponent<Animator>().SetBool("open", false);
    }
    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        // Show menu puntuacion (pass insignias and time)
        Camera.main.transform.GetChild(0).gameObject.SetActive(true);
        Camera.main.transform.GetChild(1).gameObject.SetActive(true);
    }
}
