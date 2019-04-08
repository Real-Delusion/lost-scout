using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject menuPausa;
    public bool cursorState;

    // Start is called before the first frame update
    void Start()
    {
        cursorState = Cursor.visible;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleMenuPausa(){
        //menuPausa.GetComponent<Canvas> ().enabled = true;
        cursorState = !cursorState;
        menuPausa.SetActive(!menuPausa.activeSelf);
        Cursor.visible = cursorState;
    }
}
