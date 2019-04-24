using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour
{
    public GameObject menuPausa;
    public GameObject menuPuntuacion;
    public GameObject insigniaHabilidadGrey;
    public GameObject insigniaPrestigioGrey;
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
        menuPausa.SetActive(state);
    }

    public void showMenuPuntuacion (int insignias, float time){
        menuPuntuacion.SetActive(true);
        tiempo.text = (Math.Round(time,2).ToString())+" s";
        if(insignias >= 2){
            insigniaHabilidadGrey.SetActive(false);
        }else{
            insigniaHabilidadGrey.SetActive(true); 
        }
        if(insignias >= 3){
            insigniaPrestigioGrey.SetActive(false);
        }else{
            insigniaPrestigioGrey.SetActive(true);
        }
    }

    public void hideMenuPuntuacion (){
        menuPuntuacion.SetActive(false);
    }
    public void showBienHecho()
    {
        StartCoroutine(Wait());
        bienHecho.SetActive(true);

    }
    public void hideBienHecho()
    {
        bienHecho.SetActive(false);
    }
    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(1f);
        // Show menu puntuacion (pass insignias and time)
        Camera.main.transform.GetChild(0).gameObject.SetActive(true);
        Camera.main.transform.GetChild(1).gameObject.SetActive(true);
    }
}
