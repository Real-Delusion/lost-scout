using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject menuPausa;
    public GameObject menuPuntuacion;
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
        cursorState = !cursorState;
        menuPausa.SetActive(!menuPausa.activeSelf);
        Cursor.visible = cursorState;
    }

    public void showMenuPuntuacion (){
        menuPuntuacion.SetActive(true);
    }

    public void hideMenuPuntuacion (){
        menuPuntuacion.SetActive(false);
    }
}
