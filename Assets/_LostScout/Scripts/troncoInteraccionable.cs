﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Este script se asigna a un gameobject al que el player se podrá subir

public class troncoInteraccionable : MonoBehaviour
{
    // radio desde el cual se podrá interactuar
    public float radio = 1.5f;

    // player
    private GameObject player;

    // script playercontroller del player
    private PlayerController playerController;

    // altura del game object, para luego asignar la nueva posición al player
    private float miAltura;

    // constraints del rigidbody
    private RigidbodyConstraints constraints;

    // rigidbody
    private Rigidbody rb;

    // efecto mover tronco
    public GameObject efectoSmoke;

    // para ver el radio en la escena
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

        // accedemos a su script de playercontroller
        playerController = player.GetComponent<PlayerController>();

        // accedemos a la altura del game object (eje y)
        miAltura = GetComponent<Collider>().bounds.size.y;

        rb = GetComponent<Rigidbody>();

        // guardamos los constrains movibles del rigidbody
        // es decir, freeze 'Y' y todas las rotaciones
        constraints = rb.constraints;

        //efectoSmoke = GameObject.FindWithTag("efectoSmoke");
        efectoSmoke.SetActive(false);
    }


    // -------------------------------- EstadosCaja -----------------------------------
    public enum EstadosCaja
    {
        Estatico,
        Dinamico
    }

    private EstadosCaja _estado = EstadosCaja.Dinamico;

    public EstadosCaja Estado
    {
        get => _estado;
        set
        {
            _estado = value;

            // Si es dinámico, podemos desplazarlo
            if (_estado == EstadosCaja.Dinamico)
            {
                // descongelamos los constrains movibles del rigidbody
                rb.constraints = constraints;
            }

            // Si es estático, no podemos desplazarlo
            else
            {
                // congelamos los contraints del rigidbody (no se puede mover)
                rb.constraints = RigidbodyConstraints.FreezeAll;
            }
        }
    }
    // -------------------------------- EstadosCaja -----------------------------------


    // Update is called once per frame
    void Update()
    {
        // Si el jugador entra en el radio del objeto
        if (Vector3.Distance(player.transform.position, transform.position) < radio)
        {
            Debug.Log("Pulse espacio para subirse a la caja");
            // Si está en el radio y pulsa espacio
            if (Input.GetKeyDown(KeyCode.Space) | Input.GetKeyDown("joystick button 0"))
            {
                // mandamos la posición y la altura de la caja al otro script
                // el script playercontroller cambiará la posición del player usando estos parámetros
                playerController.posicionTronco = transform.position;
                playerController.alturaTronco = miAltura;

                // cambiamos el estado del player a subir
                playerController.Estado = PlayerController.EstadosPlayer.Subir;
            }

            Debug.Log("Mantén pulsado click derecho para empujar la caja");
            if ((Input.GetKey(KeyCode.Mouse1) | Input.GetKey("joystick button 0"))&& Vector3.Distance(player.transform.position, transform.position) < radio)
            {
                Estado = EstadosCaja.Dinamico;

                // cambiamos el estado del player a empujando
                playerController.Estado = PlayerController.EstadosPlayer.Empujar;
                efectoSmoke.SetActive(true);
            }
            else
            {
                Estado = EstadosCaja.Estatico;
                efectoSmoke.SetActive(false);
            }

        }

        // Si está fuera del radio del objeto
        else
        {
            Estado = EstadosCaja.Estatico;
        }

        
    }
}
