using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Este script se le asigna al player para poder desplazar/empujar objetos

public class Empujar : MonoBehaviour
{
    // float de la fuerza de empujar
    public float pushPower = 1.0f;

    // cuando colisione con algo
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // recogemos el rigidbody de la colisión
        Rigidbody body = hit.collider.attachedRigidbody;

        // si el rigidbody es nulo no debería poder mover el objeto
        if (body == null || body.isKinematic)
        {
            return;
        }
        // si el rigidbody se encuentra debajo del player no debería empujar el objeto hacia abajo
        if (hit.moveDirection.y < -0.3)
        {
            return;
        }

        // Calculamos la dirección de empujar con la dirección del movimiento
        // nunca empujaremos en el eje Y
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        // Empujar
        body.velocity = pushDir * pushPower;

    }
}
