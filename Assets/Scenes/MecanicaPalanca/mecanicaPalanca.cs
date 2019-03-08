using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mecanicaPalanca : MonoBehaviour
{
    private Animator animacionPalanca;
    public Animator animPared; 
    public float radio = 8f;
    public Transform player;

    // Maquinas de estados finitos
    public enum EstadosPalanca
    {
        On,
        Off,
    }

    private EstadosPalanca _estadoP = EstadosPalanca.Off;

    public EstadosPalanca Estado
    {
        get => _estadoP;
        set
        {
            _estadoP = value;
            if (_estadoP == EstadosPalanca.On)
            {
                animacionPalanca.SetBool("OnOff", true);
                animPared.SetBool("UpDown", true);
            }
            if (_estadoP == EstadosPalanca.Off)
            {
                animacionPalanca.SetBool("OnOff", false);
                animPared.SetBool("UpDown", false);
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        animacionPalanca = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        switch (Estado)
        {
            case EstadosPalanca.Off:
                if (Vector3.Distance(transform.position, player.position) < radio)
                {
                    if (Input.GetKey(KeyCode.E))
                    {
                        Estado = EstadosPalanca.On;
                    }
                }
                break;

            case EstadosPalanca.On:
                if (Vector3.Distance(transform.position, player.position) < radio)
                {
                    if (Input.GetKey(KeyCode.E))
                    {
                        Estado = EstadosPalanca.Off;
                    }
                }
                break;
        }

    }
    
}
