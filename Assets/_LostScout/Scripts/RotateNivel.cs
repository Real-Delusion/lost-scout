using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateNivel : MonoBehaviour
{    
    public float velocidad = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

        void Update(){
        transform.Rotate(0, velocidad * Time.deltaTime, 0);
    }
}
