using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : MonoBehaviour
{
    public GameObject hint;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //PISTA
        if (GameObject.Find("GameManager(Clone)").GetComponent<GameManager>().time > 200f)
        {
            hint.GetComponent<Animator>().SetBool("show", true);
        }

        if (GameObject.Find("GameManager(Clone)").GetComponent<GameManager>().time > 250f)
        {
            hint.GetComponent<Animator>().SetBool("show", false);
        }

    }
}
