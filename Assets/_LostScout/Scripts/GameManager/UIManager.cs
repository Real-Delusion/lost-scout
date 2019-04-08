using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject menuPausa;
    public GameObject menuPuntuacion;
    public GameObject insigniaHabilidadGrey;
    public GameObject insigniaPrestigioGrey;
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

    public void showMenuPuntuacion (int insignias, int time){
        menuPuntuacion.SetActive(true);
        if(insignias == 2){
            insigniaHabilidadGrey.SetActive(false);
        }
        if(insignias == 3){
            insigniaPrestigioGrey.SetActive(false);
        }
    }

    public void hideMenuPuntuacion (){
        menuPuntuacion.SetActive(false);
    }
}
