using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GameObject player;
    GameObject checkpoint;

    // radio desde el cual se podrá cambiar de escena tocando el checkpoint
    public float radioCheckpoint = 1.0f;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        checkpoint = GameObject.FindGameObjectWithTag("checkpoint");
        Gizmos.DrawWireSphere(checkpoint.transform.position, radioCheckpoint);
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        player = GameObject.FindGameObjectWithTag("Player");
        checkpoint = GameObject.FindGameObjectWithTag("checkpoint");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Vector3.Distance(player.transform.position, checkpoint.transform.position));
        if (Vector3.Distance(player.transform.position, checkpoint.transform.position) < radioCheckpoint)
        {
            // aquí incluir animación del player
            SceneManager.LoadScene("SelectLevel");
        }
    }

}
