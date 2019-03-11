 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Por ahora no vamos a gastar el animator ya que no tenemos animación

    //private Animator _animator;

    private CharacterController _characterController;

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
                //transform.Rotate(0, 0, 0);
                transform.localRotation.SetEulerAngles(0, 0, 0);
                Debug.Log("empujando");
                // aquí añadiremos animación de empujar del personaje
            }

            // Si el estado es subir
            if (_estado == EstadosPlayer.Subir)
            {
                Debug.Log("Subiendo");

                // la velocidad a la que subirá
                float step = velocidad * Time.deltaTime;

                // calculamos su nueva posición a partir de la posición del tronco, mi posición y las alturas
                // en los ejes x, z moverá a la posición del tronco
                // en el eje y, moverá a la posicón del tronco + su altura + la mitad de la altura del player
                nuevaPosicion = new Vector3(posicionTronco.x, posicionTronco.y + alturaTronco + miAltura/2, posicionTronco.z);
                Debug.Log("nueva = " + nuevaPosicion);

            }

            // Si el estado es subir
            if (_estado == EstadosPlayer.SubirEscalera)
            {
                // la velocidad a la que subirá
                float step = velocidad * Time.deltaTime;

                // calculamos su nueva posición a partir de la posición del tronco, mi posición y las alturas
                // en los ejes x, z moverá a la posición del tronco
                // en el eje y, moverá a la posicón del tronco + su altura + la mitad de la altura del player
                nuevaPosicion = new Vector3(transform.position.x, transform.position.y + alturaEscalera + miAltura/2, transform.position.z);
                Debug.Log("nueva = " + nuevaPosicion);

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
        Debug.Log(Estado);
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

            if (Estado == EstadosPlayer.Empujar) {
                // Si está empujando, el player no rota
                transform.Rotate(0, 0, 0);
            }
            else {
                // Si está andando rota de forma normal
                transform.Rotate(0, turnAmount * velocidadRotacion * Time.deltaTime, 0);
            }

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

        // Si el estado del player es subir, durante el movimiento de subida no podrá usar las flechas para desplazarse
        if (Estado == EstadosPlayer.Subir) {

            // Cambiamos de posición de forma smooth
            this.transform.localPosition = Vector3.Lerp(transform.position, nuevaPosicion, Time.deltaTime);
        }

        // Si el estado del player es subir escaleras
        if (Estado == EstadosPlayer.SubirEscalera) {
            // Cambiamos de posición de forma smooth

            
            t += 0.01f;

            if (t < 1.0f){
                Debug.Log(t.ToString());
                this.transform.localPosition = Vector3.Lerp(transform.position, nuevaPosicion, t);
            }else{
                this.Estado = EstadosPlayer.Andar;
                t = 0.0f;       
            }
        }
    }
}