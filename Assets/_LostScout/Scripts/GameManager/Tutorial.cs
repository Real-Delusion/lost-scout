using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject textosTutorial;
    public GameObject primerTronco;
    public GameObject primeraPalanca;
    public GameObject segundaPalanca;
    public GameObject segundoTronco;
    private float startMousePos;
    // Start is called before the first frame update
    void Start()
    {
        showMouse();
        startMousePos = Input.mousePosition.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (textosTutorial.gameObject.transform.GetChild(0).gameObject.active && startMousePos != Input.mousePosition.x) {
            StartCoroutine(Wait("move"));
        }
        if (primeraPalanca.GetComponent<mecanicaPalanca>().inRange || segundaPalanca.GetComponent<mecanicaPalanca>().inRange) {
            showLever();
        }
        else {
            hideLever();
        }        
        if (primerTronco.GetComponent<tronco>().enRadio) {
            showClimb();
        } 
        else {
            hideClimb();
        }
        if (segundoTronco.GetComponent<tronco>().enRadio) {
            showPickUp();
        }
        else {
            hidePickUp();
        }
    }

    public void showMouse() {
        textosTutorial.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        textosTutorial.gameObject.transform.GetChild(1).gameObject.SetActive(false);
        textosTutorial.gameObject.transform.GetChild(2).gameObject.SetActive(false);
        textosTutorial.gameObject.transform.GetChild(3).gameObject.SetActive(false);
        textosTutorial.gameObject.transform.GetChild(4).gameObject.SetActive(false);
    }

    public void showMovement() {
        textosTutorial.gameObject.transform.GetChild(1).gameObject.SetActive(true);
        textosTutorial.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        textosTutorial.gameObject.transform.GetChild(2).gameObject.SetActive(false);
        textosTutorial.gameObject.transform.GetChild(3).gameObject.SetActive(false);
        textosTutorial.gameObject.transform.GetChild(4).gameObject.SetActive(false);
    }

    public void showLever() {
        textosTutorial.gameObject.transform.GetChild(2).gameObject.SetActive(true);
        textosTutorial.gameObject.transform.GetChild(1).gameObject.SetActive(false);
        textosTutorial.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        textosTutorial.gameObject.transform.GetChild(3).gameObject.SetActive(false);
        textosTutorial.gameObject.transform.GetChild(4).gameObject.SetActive(false);
    }

    
    public void showPickUp() {
        textosTutorial.gameObject.transform.GetChild(4).gameObject.SetActive(true);
        textosTutorial.gameObject.transform.GetChild(1).gameObject.SetActive(false);
        textosTutorial.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        textosTutorial.gameObject.transform.GetChild(3).gameObject.SetActive(false);
        textosTutorial.gameObject.transform.GetChild(2).gameObject.SetActive(false);
    }

    public void showClimb() {
        textosTutorial.gameObject.transform.GetChild(3).gameObject.SetActive(true);
        textosTutorial.gameObject.transform.GetChild(1).gameObject.SetActive(false);
        textosTutorial.gameObject.transform.GetChild(2).gameObject.SetActive(false);
        textosTutorial.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        textosTutorial.gameObject.transform.GetChild(4).gameObject.SetActive(false);
    }
 
    public void hideClimb() {
        textosTutorial.gameObject.transform.GetChild(3).gameObject.SetActive(false);
    }
        
    public void hideLever() {
        textosTutorial.gameObject.transform.GetChild(2).gameObject.SetActive(false);
    }

    public void hidePickUp() {
        textosTutorial.gameObject.transform.GetChild(4).gameObject.SetActive(false);
    }

    IEnumerator Wait(string method)
    {
        yield return new WaitForSecondsRealtime(1);
        switch (method) {
          case "move":
              showMovement();
              break;
          case "climb":
              showClimb();
              break;
          case "lever":
              showLever();
              break;
        }
    }

}
