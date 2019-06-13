using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : MonoBehaviour
{
    public GameObject hint;
    public  GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager(Clone)");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.GetComponent<GameManager>().finishedLevel)
        {
            hint.GetComponent<Animator>().SetBool("show", false);
        }

        if (!gameManager.GetComponent<GameManager>().finishedLevel)
        {
            //PISTA
            if (GameObject.Find("GameManager(Clone)").GetComponent<GameManager>().time > 150f)
            {
                hint.GetComponent<Animator>().SetBool("show", true);
            }
            if (GameObject.Find("GameManager(Clone)").GetComponent<GameManager>().time > 180f)
            {
                hint.GetComponent<Animator>().SetBool("show", false);
            }
        }
    }
}
