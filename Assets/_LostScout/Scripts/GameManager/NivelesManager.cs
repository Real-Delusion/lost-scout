﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NivelesManager : MonoBehaviour
{
    public GameManager gameManager;
    public Transform lvlBtn;
    public GameObject CanvasTarget;
    public List<Sprite> miniaturas;
    public Sprite lockedMarco;
    private GameObject numeroNivel;
    private static string selectedLevel;
    public int unlockedId = -1;

    public List<Nivel> levels;
    public static int paginaNivel;

    void Start()
    {
        paginaNivel = 0;
        gameManager = GetComponent<GameManager>();   
    }

    public void printLevels()
    {

        foreach (Transform child in GameObject.FindWithTag("NivelesCanvas").transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        foreach (Transform child in GameObject.FindWithTag("NivelesCanvas2").transform)
        {
            GameObject.Destroy(child.gameObject);
        }
//        Debug.Log((paginaNivel + 2));

        for (int i = paginaNivel; i < (paginaNivel + 6); i++)
        {
            if (i <= (paginaNivel + 2))
            {
                CanvasTarget = GameObject.FindWithTag("NivelesCanvas");
            }
            else
            {
                CanvasTarget = GameObject.FindWithTag("NivelesCanvas2");
            }

            Transform obj = Instantiate(lvlBtn);
            obj.transform.SetParent(CanvasTarget.transform);

            /*Vector3 newpos = obj.transform.position;
            newpos.x = pos; 
            newpos.y = 327; 
            newpos.z = 0; */

            obj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            //obj.transform.position = newpos;

            Image[] images = obj.GetComponentsInChildren<Image>();

            Image miniatura = images[0];
            miniatura.sprite = miniaturas[i];

            Button btn = obj.gameObject.GetComponent<Button>();
            Image miniaturaAnim = btn.transform.Find("miniaturaAnim").GetChild(1).GetComponent<Image>();
            miniaturaAnim.sprite = miniaturas[i];
            Nivel t = GameManager.niveles[i];

            //Asginar número a cada nivel
            btn.transform.Find("Numero").GetChild(1).GetComponent<Text>().text = (t.ID + 1).ToString();

            if (!GameManager.niveles[i].Locked)
            {
                btn.onClick.AddListener(() => LoadModal(t));
                int insignias = GameManager.niveles[i].Insignias;
                //Debug.Log(i + GameManager.niveles[i].LevelName + ": " + GameManager.niveles[i].Insignias);

                if (insignias >= 1)
                {
                    obj.transform.Find("obsequio_grey").gameObject.SetActive(false);
                }
                else
                {
                    obj.transform.Find("obsequio_grey").gameObject.SetActive(true);
                }
                if (insignias >= 2)
                {
                    obj.transform.Find("habilidad_grey").gameObject.SetActive(false);
                }
                else
                {
                    obj.transform.Find("habilidad_grey").gameObject.SetActive(true);
                }
                if (insignias >= 3)
                {
                    obj.transform.Find("prestigio_grey").gameObject.SetActive(false);
                }
                else
                {
                    obj.transform.Find("prestigio_grey").gameObject.SetActive(true);
                }
                
                if (i == unlockedId && unlockedId != 0) {
                    unlockedId = -1;
                    animateUnlock(obj);
                } 
            }
            else
            {
                Image marco = images[1];
                marco.sprite = lockedMarco;
                btn.onClick.AddListener(() => LoadModal(t));
            }
            GameObject.FindWithTag("NivelesCanvas").GetComponent<Animator>().SetBool("in", true);
            //GameObject.FindWithTag("NivelesCanvas2").GetComponent<Animator>().SetBool("in", true);
            //pos += 175;

        }

    }

    public void nextScreen()
    {
        GameObject.Find("atras").GetComponent<Image>().enabled = true;
        GameObject.Find("adelante").GetComponent<Image>().enabled = false;
        if (paginaNivel < 6)
        {
            paginaNivel += 6;
            printLevels();
        }
    }

    public void backScreen()
    {
        GameObject.Find("atras").GetComponent<Image>().enabled = false;
        GameObject.Find("adelante").GetComponent<Image>().enabled = true;
        paginaNivel -= 6;
        printLevels();

    }

    void LoadModal(Nivel level)
    {
        selectedLevel = level.LevelName;
        GameObject.Find("LevelText").GetComponent<Text>().text = "LEVEL " + (level.ID + 1).ToString();
        GameObject.FindWithTag("CanvasModal").GetComponent<Canvas>().enabled = true;
        GameObject.FindWithTag("CanvasModal").transform.Find("ModalContent").gameObject.GetComponent<Animator>().SetBool("open", true);
        GameObject.Find("marcoLocked").GetComponent<Image>().enabled = false;
        GameObject.Find("botonJugar").GetComponent<Button>().interactable = true;
        GameObject.Find("imageNivel").GetComponent<Image>().sprite = miniaturas[level.ID];
        if (level.LevelName == "Level Tutorial") GameObject.Find("TextObsequio").GetComponent<Text>().text = "Complete Tutorial";
        else GameObject.Find("TextObsequio").GetComponent<Text>().text = "Complete level " + (level.ID+1);
        GameObject.Find("TextHabilidad").GetComponent<Text>().text = "Finish in less than " + level.MaxTime + "s";
        GameObject.Find("TextPrestigio").GetComponent<Text>().text = "Clear course in " + level.MaxInteractions + " touches";
        if (level.RecordTime != -1) GameObject.Find("TextTime").GetComponent<Text>().text = System.Math.Round(level.RecordTime,2).ToString() + "s";
        else GameObject.Find("TextTime").GetComponent<Text>().text = "--";

        if (level.Locked)
        {
            GameObject.Find("marcoLocked").GetComponent<Image>().enabled = true;
            GameObject.Find("botonJugar").GetComponent<Button>().interactable = false;
        }

        if (level.Insignias >= 1)
        {
            GameObject.Find("imageObsequioDes").GetComponent<Image>().enabled = false;
        }
        else
        {
            GameObject.Find("imageObsequioDes").GetComponent<Image>().enabled = true;
        }
        if (level.Insignias >= 2)
        {
            GameObject.Find("imageHabilidadDes").GetComponent<Image>().enabled = false;
        }
        else
        {
            GameObject.Find("imageHabilidadDes").GetComponent<Image>().enabled = true;
        }
        if (level.Insignias >= 3)
        {
            GameObject.Find("imagePrestigioDes").GetComponent<Image>().enabled = false;
        }
        else
        {
            GameObject.Find("imagePrestigioDes").GetComponent<Image>().enabled = true;
        }
    }

    public void closeModal()
    {
        //GameObject.FindWithTag("CanvasModal").GetComponent<Canvas>().enabled = false;
        GameObject.FindWithTag("CanvasModal").transform.Find("ModalContent").gameObject.GetComponent<Animator>().SetBool("open", false);
    }

    public void LoadLevel()
    {
        //SceneManager.LoadScene(selectedLevel);
        GameManager.sceneTransitions.load(selectedLevel);
    }

    public void animateUnlock(Transform boton) {

        boton.Find("Numero").GetComponent<Animator>().SetBool("esconder", true);
        boton.transform.Find("miniaturaAnim").gameObject.SetActive(true);
        StartCoroutine(Wait(boton));
    }

    IEnumerator Wait(Transform boton)
    {
        yield return new WaitForSecondsRealtime(4f);
        //if (SceneManager.GetActiveScene().ToString() == "MainMenuScreen") {
        boton.transform.Find("miniaturaAnim").gameObject.SetActive(false);
        boton.Find("Numero").GetComponent<Animator>().SetBool("esconder", false);

        //}
    }
}
