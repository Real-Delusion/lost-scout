using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneTransitions : MonoBehaviour
{
    public Canvas canvas;
    public Animator transitionAnim;
    AsyncOperation asyncLoadLevel;

    public void load(string sceneName)
    {
        StartCoroutine(LoadScene(sceneName));
    }

    IEnumerator LoadScene(string sceneName)
    {
        canvas.sortingOrder = 999;
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(.5f);
    
        asyncLoadLevel = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoadLevel.isDone)
        {
            //print("Loading the Scene");
            yield return null;
        }

        transitionAnim.SetTrigger("start");
        yield return new WaitForSeconds(.5f);
        canvas.sortingOrder = 0;
    }

}
