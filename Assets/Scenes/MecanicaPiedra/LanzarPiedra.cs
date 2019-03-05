using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzarPiedra : MonoBehaviour
{
    public GameObject objeto;
    public float m_jumpX;
    public float m_jumpY;
    public float vel;

    private Rigidbody rbody;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject piedra = Instantiate(objeto) as GameObject;
            piedra.transform.position = transform.position + transform.forward * 2;
            Rigidbody rb = piedra.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * vel;
            //rb.AddForce(new Vector3 (m_jumpX,m_jumpY,0.0f));
        }
    }

}
