using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzarPiedra : MonoBehaviour
{
    //Prefab piedra
    public GameObject objeto;
    //Regular parábola en el eje Y
    public float m_jumpY = 50f;
    //Velocidad lanzamiento piedra
    public float vel = 2f;

    private bool piedra; //La piedra es false cuando no está en el escenario

    // Update is called once per frame
    void Update()
    {
       
       if ((Input.GetKeyDown(KeyCode.Mouse0) | Input.GetKeyDown("joystick button 5") )&& !piedra) // Si se pulsa el boton izq. del mouse y la piedra es false
       {
                //Creo una nueva piedra
                GameObject nuevoSteak = Instantiate(objeto) as GameObject;
                //Posicion donde empieza la piedra
                nuevoSteak.transform.position = transform.position + transform.forward * 1; //El 1 es la distancia entre la piedra y el personaje al lanzarla
                //Buscar rigidbody de la piedra
                Rigidbody rb = nuevoSteak.GetComponent<Rigidbody>();
                //Añadir velocidad a la piedra
                rb.velocity = transform.forward * vel;
                //Añadir una fuerza en el eje Y
                rb.AddForce(new Vector3(0, m_jumpY, 0));
                piedra = true; //La piedra está en el escenario
                
        }
        //Destruir piedra a los 5s
        Destroy(GameObject.Find("steak(Clone)"), 5);

        if (!GameObject.Find("steak(Clone)")) //Si no hay ningun objeto que se llame Piedra(Clone), puedes volver a lanzar la piedra
        {
            piedra = false; //La piedra no está en el escenario
        }

    }

}
