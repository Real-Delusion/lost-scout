using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject menuPausa;
    public GameObject menuPuntuacion;
    public GameObject insigniaHabilidadGrey;
    public GameObject insigniaPrestigioGrey;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleMenuPausa(bool state){
        menuPausa.SetActive(state);
        Cursor.visible = state;
    }

    public void showMenuPuntuacion (int insignias, float time){
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
