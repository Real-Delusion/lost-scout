using System.Collections;
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

    public List<Nivel> levels;
    public static int paginaNivel;

    void Start()
    {
        paginaNivel = 0;
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
        Debug.Log((paginaNivel + 2));

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

            var obj = Instantiate(lvlBtn);
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
            var t = GameManager.niveles[i].LevelName;
            if (!GameManager.niveles[i].Locked)
            {
                btn.onClick.AddListener(() => LoadLevel(t));
            }
            else
            {
                Image marco = images[1];
                marco.sprite = lockedMarco;
            }

            //pos += 175;
        }
    }

    public void nextScreen()
    {
        paginaNivel += 6;
        printLevels();
    }

    public void backScreen()
    {
        if (paginaNivel == 0)
        {
            gameManager = GetComponent<GameManager>();
            gameManager.fromGame = false;
            SceneManager.LoadScene("MainMenuScreen");
        }
        else
        {
            paginaNivel -= 6;
            printLevels();
        }

    }


    void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
