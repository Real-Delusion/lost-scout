using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    public Transform player;

    public float radio = 6f;

    public Transform[] ruta;

    private int destino;

    private NavMeshAgent agente;

    public enum EstadosPatrulleros
    {
        Patrulla,

        Ataque,

        Distraido
    }

    private EstadosPatrulleros _estado = EstadosPatrulleros.Patrulla;

    public EstadosPatrulleros Estado { get => _estado; 
    
    set { 
    
            _estado = value;
            if(_estado == EstadosPatrulleros.Patrulla)
            {
                SiguientePunto();
            }

        } 
    
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        if(Estado == EstadosPatrulleros.Ataque)
        {
            Gizmos.color = Color.red;
        }
        Gizmos.DrawWireSphere(transform.position, radio);
    }

    // Start is called before the first frame update
    void Start()
    {
        agente = GetComponent<NavMeshAgent>(); //Le asigno el objeto nav mesh de unity que quiero que sea el agente
        //agente.destination = punto.position; //Para que vaya a un punto
        //SiguientePunto();

    }
    // Update is called once per frame
    void Update()
    {
        GameObject piedra = GameObject.Find("Stone_2(Clone)");
        
        //Según en que estado este el patrullero 
        switch (Estado)
        {
            case EstadosPatrulleros.Patrulla:
                //Solo se ejecutará si ya tiene el camino calculado
                if (!agente.pathPending && agente.remainingDistance < .5f)
                {
                    SiguientePunto();
                }
                if (Vector3.Distance(transform.position, player.position) < radio)
                {
                    Estado = EstadosPatrulleros.Ataque;
                }
                if(piedra != null){
                    if (Vector3.Distance(transform.position, piedra.transform.position) < radio)
                    {
                        Estado = EstadosPatrulleros.Distraido;
                    }
                }
                break;
            case EstadosPatrulleros.Ataque:
                agente.destination = player.position;
                if (Vector3.Distance(transform.position, player.position) > radio)
                {
                    Estado = EstadosPatrulleros.Patrulla;
                }
                break;
            case EstadosPatrulleros.Distraido:
                if (piedra != null)
                {
                    agente.destination = piedra.transform.position;
                }else{
                    Estado = EstadosPatrulleros.Patrulla;
                }
            break;
        }


      

    }
    void SiguientePunto()
    {
        if (ruta.Length == 0)
        {
            return;
        }
        agente.destination = ruta[destino].position;
        destino = (destino + 1) % ruta.Length; //el resto es la nueva posición, para calcular cuando acaba la ruta
    }
}
