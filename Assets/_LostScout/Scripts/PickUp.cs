using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    // Minimum distance to pickup
    public float range = 5;
    // Item (to pickup)
    public GameObject item;

    private RigidbodyConstraints constraints;

    // 
    public GameObject tempParent; 
    public Transform guide;

    // Is carrying?? 
    bool carrying;

    // Use this for initialization
    void Start()
    {
        item = gameObject;
        constraints = item.GetComponent<Rigidbody>().constraints;
        item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        guide = GameObject.Find("guide").transform;
        tempParent = GameObject.Find("guide");
        item.GetComponent<Rigidbody>().useGravity = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (item.transform.position.y < 0.005)
        {
            item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }else{
            item.GetComponent<Rigidbody>().constraints = constraints;
        }
        if (carrying == false){
            if (Input.GetKeyDown(KeyCode.E) && (guide.transform.position - transform.position).sqrMagnitude < range * range) {
            pickup();
            carrying = true;
            }
        }
        else if (carrying == true) {
            if (Input.GetKeyDown(KeyCode.E))
            {
                drop();
                carrying = false;
            }
        }
    }

    void pickup()
    {
        item.GetComponent<Rigidbody>().constraints = constraints;
        item.GetComponent<Rigidbody>().useGravity = false;
        item.GetComponent<Rigidbody>().isKinematic = true;
        item.transform.position = guide.transform.position;
        item.transform.rotation = guide.transform.rotation;
        item.transform.parent = tempParent.transform;

        item.GetComponent<Rigidbody>().constraints = constraints;

        // Activate and and modify player collider
        guide.transform.root.GetComponent<CharacterController>().radius = 0.6f;
        guide.transform.root.GetComponent<CharacterController>().center = new Vector3(0,0.8f,0.2f);
    }
    void drop()
    {
        item.GetComponent<Rigidbody>().useGravity = true;
        item.GetComponent<Rigidbody>().isKinematic = false;
        item.transform.parent = null;
        item.transform.position = guide.transform.position;

        // Deactivate and restore default player collider
        guide.transform.root.GetComponent<CharacterController>().radius = 0.3f;
        guide.transform.root.GetComponent<CharacterController>().center = new Vector3(0,0.8f,0);
    }
}
