using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Este script desactiva un collider cualquiera a partir de la posición del hijo de un objeto,
// así podemos abrir/cerrar caminos dependiendo de dónde se encuentre un objeto (como un rio, 
// un puente, una plataforma etc)
public class DesactivarCollider : MonoBehaviour
{
    // La posición la escribimos en Unity
    public float xPosicion;
    public float yPosicion;
    public float zPosicion;

    // El collider que queremos desactivar, asignamos en Unity
    public Collider colliderObjeto;
    private Vector3 posicion;

    void Start()
    {
        // La posición a partir de la cual desactivamos el collider
        posicion = new Vector3(xPosicion, yPosicion, zPosicion);

        //Debug.Log(posicion);
        //Debug.Log(colliderObjeto);
    }

    void Update()
    {   
        //float idk = transform.GetChild(0).position.z;
        //float pos = posicion.z;
        //Debug.Log("child " + idk);
        //Debug.Log("pos " + pos);
        if (transform.GetChild(0).position == posicion) {
            colliderObjeto.enabled = false;
        }
        else {
            colliderObjeto.enabled = true;
        }
    }
}
