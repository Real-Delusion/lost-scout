 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Por ahora no vamos a gastar el animator ya que no tenemos animación

    //private Animator _animator;

    private CharacterController _characterController;

    // ------------------------------ Para la piedra --------------------------------
    private bool piedra; //La piedra es false cuando no está en el escenario
    public GameObject objeto;

    public float m_jumpY = 50f;
    //Velocidad lanzamiento piedra
    public float vel = 2f;


    // ------------------------------ Para el movimiento --------------------------------
    public float velocidad = 5.0f;

    public float velocidadRotacion = 240.0f;

    private float gravedad = 20.0f;

    private Vector3 _dirMov = Vector3.zero;
    private float turnAmount;


    // -----------------------------------------------------------------------------------


    // ------------------------------ Para subir a sitios --------------------------------

    public Vector3 posicionTronco;

    public float alturaTronco;
    public float alturaEscalera;

    private float miAltura;

    private Vector3 nuevaPosicion;

    static float t = 0.0f;
    // -----------------------------------------------------------------------------------


    // -------------------------------- EstadosPlayer -----------------------------------
    public enum EstadosPlayer
    {
        Andar,
        Empujar,
        Subir,
        SubirEscalera
    }

    private EstadosPlayer _estado = EstadosPlayer.Andar;

    public EstadosPlayer Estado
    {
        get => _estado;
        set
        {
            _estado = value;

            // Si el estado es empujar
            if (_estado == EstadosPlayer.Empujar)
            {
                Debug.Log("empujando");
                // aquí añadiremos animación de empujar del personaje
            }

            // Si el estado es subir
            if (_estado == EstadosPlayer.Subir)
            {
                Debug.Log("Subiendo");

                // calculamos su nueva posición a partir de la posición del tronco, mi posición y las alturas
                // en los ejes x, z moverá a la posición del tronco
                // en el eje y, moverá a la posicón del tronco + su altura + la mitad de la altura del player
                nuevaPosicion = new Vector3(posicionTronco.x, posicionTronco.y + alturaTronco + miAltura - _characterController.height + 0.16f - _characterController.radius - _characterController.center.y, posicionTronco.z);
                Debug.Log("nueva = " + nuevaPosicion);

            }

            // Si el estado es subir
            if (_estado == EstadosPlayer.SubirEscalera)
            {
                // calculamos su nueva posición a partir de la posición del tronco, mi posición y las alturas
                // en los ejes x, z moverá a la posición del tronco
                // en el eje y, moverá a la posicón del tronco + su altura + la mitad de la altura del player
                nuevaPosicion = new Vector3(transform.position.x, transform.position.y + alturaEscalera + (miAltura+5)/2, transform.position.z);
                Debug.Log("Estado: Subir escalera");

            }
        }
    }
    // -------------------------------- EstadosPlayer -----------------------------------



    //-----------------------------------------------

    // Use this for initialization
    void Start()
    {
        //_animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
        
        // accedemos a la altura del game object (eje y)
        miAltura = GetComponent<Collider>().bounds.size.y;

    }

    //------------------------------------------------

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Estado);
        // Si el estado del player es andar o empujar, se mantendrá el movimiento normal del player (con flechas)
        if (Estado == EstadosPlayer.Andar || Estado == EstadosPlayer.Empujar)
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
            turnAmount = Mathf.Atan2(move.x, move.z);
            
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

         // Si el estado del player es subir escaleras
        if (Estado == EstadosPlayer.Subir) {
            
            t += 0.01f;

            if (t < 0.2f){
                //Debug.Log(t.ToString());
                // Cambiamos de posición de forma smooth
                this.transform.localPosition = Vector3.Lerp(transform.position, nuevaPosicion, t);
            }else{
                this.Estado = EstadosPlayer.Andar;
                t = 0.0f;       
            }
        }

        // Si el estado del player es subir escaleras
        if (Estado == EstadosPlayer.SubirEscalera) {
            Debug.Log(Input.GetAxis("Vertical"));

           /* t += 0.03f;

            if (t < 1.0f){
                Debug.Log("Subiendo");
                // Cambiamos de posición de forma smooth
                this.transform.localPosition = Vector3.Lerp(transform.position, nuevaPosicion, t);
            }else{
                this.Estado = EstadosPlayer.Andar;
                t = 0.0f;       
            } */
            
              if (Input.GetAxis("Vertical") > 0)
             {
                 transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * velocidad);
             }
             if (Input.GetAxis("Vertical") < 0)
             {
                 transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * velocidad);
             }
        }

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

                //Destruir piedra a los 5s
                Destroy(GameObject.Find("steak(Clone)"), 5);   
        }

        if (!GameObject.Find("steak(Clone)")) //Si no hay ningun objeto que se llame Piedra(Clone), puedes volver a lanzar la piedra
        {
            piedra = false; //La piedra no está en el escenario
        }
    }
}