using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzarPiedra : MonoBehaviour
{
    public GameObject objeto;
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
            piedra.transform.position = transform.position + transform.forward * 1;
            Rigidbody rb = piedra.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * vel;
            rb.AddForce(new Vector3(0,m_jumpY,0));
        }

        Destroy(GameObject.Find("Piedra(Clone)"), 5);
    }

}
