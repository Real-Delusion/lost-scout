using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject menuPausa;
    public bool menuPausaState = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleMenuPausa(){
        //menuPausa.GetComponent<Canvas> ().enabled = true;
        menuPausaState = !menuPausaState;
        menuPausa.SetActive(menuPausaState);
    }
}
