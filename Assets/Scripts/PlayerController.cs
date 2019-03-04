using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Por ahora no vamos a gastar el animator ya que no tenemos animación

    //private Animator _animator;

    private CharacterController _characterController;

    public float velocidad = 5.0f;

    public float velocidadRotacion = 240.0f;

    private float gravedad = 20.0f;

    private Vector3 _dirMov = Vector3.zero;


    //-----------------------------------------------

    // Use this for initialization
    void Start()
    {
        //_animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
    }

    //------------------------------------------------

    // Update is called once per frame
    void Update()
    {
        // obtenemos los inputs

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // Cálculamos el vector hacia delante
        Vector3 camForward_Dir = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 move = v * camForward_Dir + h * Camera.main.transform.right;

        if (move.magnitude > 1f) move.Normalize();

        // Cálculamos la rotación del jugador
        move = transform.InverseTransformDirection(move);

        // Obtenemos los angulos de Euler
        float turnAmount = Mathf.Atan2(move.x, move.z);

        transform.Rotate(0, turnAmount * velocidadRotacion * Time.deltaTime, 0);

        //Si el personaje esta tocando tierra...

        if (_characterController.isGrounded)
        {
            // --- _animator.SetBool("run", move.magnitude> 0);

            _dirMov = transform.forward * move.magnitude;

            _dirMov *= velocidad;

        }

        _dirMov.y -= gravedad * Time.deltaTime;

        _characterController.Move(_dirMov * Time.deltaTime);
    }
}