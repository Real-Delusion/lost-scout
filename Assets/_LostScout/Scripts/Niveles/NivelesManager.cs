using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 using UnityEngine.UI;

public class NivelesManager : MonoBehaviour
{
    public Transform lvlBtn;
    public List<Nivel> niveles;

    void Start()
    {
        niveles =  new List<Nivel>();
        var nivel1 = new Nivel(1,"Nivel 1",false,0,false);
        niveles.Add(nivel1);
        Debug.Log(niveles[0].LevelName);
         foreach (var level in niveles) {
            var obj = Instantiate(lvlBtn);
            Button btn = obj.gameObject.GetComponent<Button>();
            var t = level.LevelName;
            btn.onClick.AddListener(() => LoadLevel(t));
        }    }
    

    void LoadLevel (string levelName){
        SceneManager.LoadScene(levelName);
    }
}
