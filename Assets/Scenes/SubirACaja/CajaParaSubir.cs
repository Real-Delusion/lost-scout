using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaParaSubir : MonoBehaviour
{
    // radio desde el cual se podrá interactuar
    public float radio = 1.5f;

    // player
    private GameObject player;

    // script empujarcaja del player
    private SubirACaja subirScript;

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radio);
    }

    // Start is called before the first frame update
    void Start()
    {
        // guardamos el player con el tag
        player = GameObject.FindGameObjectWithTag("Player");

        // accedemos a su script de empujarcaja
        subirScript = player.GetComponent<SubirACaja>();
    }

    // Update is called once per frame
    void Update()
    {
        // Si el jugador entra en el radio del objeto
        if (Vector3.Distance(player.transform.position, transform.position) < radio)
        {
            Debug.Log("Pulse E para subirse a la caja");
            if (Input.GetKeyDown(KeyCode.E))
            {
                // cambiamos el estado del player a empujando
                subirScript.Estado =SubirACaja.EstadosPlayer.Subir;
            }
            else
            {
                // mientras no pulse E
                // mantenemos el estado del player en andando
                subirScript.Estado = SubirACaja.EstadosPlayer.Andar;
            }
        }

        // Si está fuera del radio del objeto
        else
        {
            // cambiamos el estado del player a andando
            subirScript.Estado = SubirACaja.EstadosPlayer.Andar;
        }
    }
}
