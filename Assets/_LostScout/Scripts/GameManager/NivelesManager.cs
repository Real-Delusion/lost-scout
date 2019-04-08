using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 using UnityEngine.UI;

public class NivelesManager : MonoBehaviour
{
    //private GameManager gameManager;
    public Transform lvlBtn;
    public GameObject CanvasTarget;
    public List<Sprite> miniaturas;
    public Sprite lockedMarco;

    void Start()
    {
    }

    public void printLevels(List<Nivel> levels){
        CanvasTarget = GameObject.FindWithTag("NivelesCanvas");    
        //gameManager = GetComponent<GameManager>();        
        int pos = 250;
        int i = 0;
        foreach (var level in levels) {
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

            pos += 400;
            i++;
        } 
    }
    

    void LoadLevel (string levelName){
        SceneManager.LoadScene(levelName);
    }
}
