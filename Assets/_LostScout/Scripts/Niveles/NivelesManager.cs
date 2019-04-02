using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 using UnityEngine.UI;

public class NivelesManager : MonoBehaviour
{
    public Transform lvlBtn;
    public List<Nivel> niveles;
    public GameObject CanvasTarget;
    public List<Sprite> miniaturas;
    public Sprite lockedMarco;

    void Start()
    {       
        niveles =  new List<Nivel>();
        var nivel1 = new Nivel(1,"Nivel 1",false,0,false);
        var nivel2 = new Nivel(2,"Nivel 2",false,0,false);
        var nivel3 = new Nivel(3,"Nivel 3",false,0,true);
        
        niveles.Add(nivel1);
        niveles.Add(nivel2);
        niveles.Add(nivel3);
        Debug.Log(niveles[0].LevelName);

        int pos = 1010;
        
        int i = 0;
        foreach (var level in niveles) {
            var obj = Instantiate(lvlBtn);
            obj.transform.SetParent(CanvasTarget.transform);

            Vector3 newpos = obj.transform.position;
            newpos.x = pos; 
            newpos.y = 327; 
            newpos.z = 0; 
            obj.transform.position = newpos;

            Image[] images = obj.GetComponentsInChildren<Image>();
            
            Image miniatura = images[0];
            miniatura.sprite = miniaturas[i];

            Button btn = obj.gameObject.GetComponent<Button>();
            var t = level.LevelName;
            if (!level.Locked){
                btn.onClick.AddListener(() => LoadLevel(t));
            }else
            {
                Image marco = images[1];
                marco.sprite = lockedMarco;
            }

            pos -= 400;
            i++;
        }        
    }
    

    void LoadLevel (string levelName){
        SceneManager.LoadScene(levelName);
    }
}
