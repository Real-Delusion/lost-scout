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

    public GameObject camaraText;
    public GameObject moveText;
    public GameObject leverText;
    public GameObject climbtext;
    public GameObject pickUpText;
    GameObject player;
    bool pressedE = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        camaraText =  textosTutorial.gameObject.transform.GetChild(0).gameObject;
        moveText = textosTutorial.gameObject.transform.GetChild(1).gameObject;
        leverText = textosTutorial.gameObject.transform.GetChild(2).gameObject;
        climbtext = textosTutorial.gameObject.transform.GetChild(3).gameObject;
        pickUpText = textosTutorial.gameObject.transform.GetChild(4).gameObject;

        // bloquea el movimiento del player al principio
        player.GetComponent<PlayerController>().enabled = false;
        
        showMouse();
        leverText.SetActive(true);
        startMousePos = Input.mousePosition.x;
    }

    // Update is called once per frame
    void Update()
    {
        // ROTAR CAMARA
        if (camaraText.activeSelf && startMousePos != Input.mousePosition.x) {
            StartCoroutine(Wait("move"));
        }

        // ACCIONAR PALANCA
        if (primeraPalanca.GetComponent<mecanicaPalanca>().inRange || segundaPalanca.GetComponent<mecanicaPalanca>().inRange) {
            StartCoroutine(Wait("lever"));
        }
        else if (!primeraPalanca.GetComponent<mecanicaPalanca>().inRange && !segundaPalanca.GetComponent<mecanicaPalanca>().inRange) {
            StartCoroutine(Wait("hidelever"));
        } 

        // SUBIR TRONCO  
        if (primerTronco.GetComponent<tronco>().enRadio && player.transform.position.y <= 0.05) {
            StartCoroutine(Wait("climb"));
        } 
        else {
            hideClimb();
        }

        // COGER TRONCO
        if (segundoTronco.GetComponent<tronco>().enRadio && !segundoTronco.GetComponent<tronco>().carrying) {
            StartCoroutine(Wait("pickup"));
        }
        else {
            hidePickUp();
        }
    }

    public void showMouse() {
        camaraText.SetActive(true);
        if (camaraText.activeSelf == true)
        camaraText.GetComponent<Animator>().SetBool("show", true);
        moveText.SetActive(false);
        climbtext.SetActive(false);
        pickUpText.SetActive(false);
    }

    public void showMovement() {
        camaraText.SetActive(false);
        moveText.SetActive(true);
        if (moveText.activeSelf == true)
        moveText.GetComponent<Animator>().SetBool("show", true);
    }

    public void showLever() {
        moveText.SetActive(false);
        leverText.SetActive(true);
        if (leverText.activeSelf == true)
        leverText.GetComponent<Animator>().SetBool("show", true);
    }

    public void showClimb() {
        climbtext.SetActive(true);
        if (climbtext.activeSelf == true &&  climbtext.GetComponent<Animator>().GetBool("show") == false)
        climbtext.GetComponent<Animator>().SetBool("show", true);
    }

    public void showPickUp() {
        pickUpText.SetActive(true);
        if (pickUpText.activeSelf == true)
        pickUpText.GetComponent<Animator>().SetBool("show", true);
    }

    public void hideMouse() {
        camaraText.GetComponent<Animator>().SetBool("show", false);
    }

    public void hideMovement() {
        if (moveText.GetComponent<Animator>().GetBool("show"))
        moveText.GetComponent<Animator>().SetBool("show", false);
    }
 
    public void hideLever() {
        if (leverText.activeSelf == true)
        leverText.GetComponent<Animator>().SetBool("show", false);
    }
    public void hideClimb() {
        if (climbtext.activeSelf == true)
        climbtext.GetComponent<Animator>().SetBool("show", false);
    }

    public void hidePickUp() {
        if (pickUpText.activeSelf == true)
        pickUpText.GetComponent<Animator>().SetBool("show", false);
    }

    IEnumerator Wait(string method)
    {
        switch (method) {
          case "move":
                yield return new WaitForSecondsRealtime(3);
                hideMouse();
                yield return new WaitForSecondsRealtime(0.5f);
                player.GetComponent<PlayerController>().enabled = true;
                showMovement();
                break;
          case "lever":
                hideMovement();
                yield return new WaitForSecondsRealtime(0.5f);
                showLever();
                break;
          case "hidelever":
                hideLever();
                yield return new WaitForSecondsRealtime(0.5f);
                break;
          case "climb":
                yield return new WaitForSecondsRealtime(0.5f);
                showClimb();
                break;
          case "pickup":
                yield return new WaitForSecondsRealtime(0.5f);
                showPickUp();
                break;
        }
    }

}
