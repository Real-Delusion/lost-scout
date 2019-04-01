using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlCamaraMenu : MonoBehaviour
{
    public Transform CamTransform;
    public Transform PointTransform;

    public void moverCamara() {

        CamTransform.position = PointTransform.position;
    }
}
