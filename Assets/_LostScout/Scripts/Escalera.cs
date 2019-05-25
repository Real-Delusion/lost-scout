using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escalera : MonoBehaviour
{
    GameObject player;
    bool canClimb = false;
    public float speed = 1;

    // script playercontroller del player
    private PlayerController playerController;

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player" && player.transform.position.y < (transform.localScale.y))
        {
            Debug.Log("true");
            canClimb = true;
            player.GetComponent<PlayerController>().Estado = PlayerController.EstadosPlayer.SubirEscalera;
        }
    }

    void OnTriggerExit(Collider coll2)
    {
        if (coll2.gameObject.tag == "Player")
        {
            Debug.Log("false");
            canClimb = false;
            player.GetComponent<PlayerController>().Estado = PlayerController.EstadosPlayer.Andar;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // guardamos el player con el tag
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
    }
    void Update()
    {
    }
}
