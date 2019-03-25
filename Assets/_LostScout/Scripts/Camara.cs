using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform TargetTransform;

    private Vector3 _cameraOffset;

    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;

    public bool LookAtTarget = false;

    public bool RotateAroundTarget = true;

    public bool RotateMiddleMouseButton = true;

    public float RotationsSpeed = 5.0f;

    public float CameraPitchMin = 1.5f;

    public float CameraPitchMax = 6.5f;

    // Use this for initialization
    void Start()
    {
        _cameraOffset = transform.position - TargetTransform.position;
    }

    private bool IsRotateActive
    {
        get
        {
            if (!RotateAroundTarget)
                return false;

            if (!RotateMiddleMouseButton)
                return true;

            if (RotateMiddleMouseButton && Input.GetMouseButton(2))
                return true;

            return false;
        }
    }

    // LateUpdate is called after Update methods
    void LateUpdate()
    {
        if (IsRotateActive)
        {

            float h = Input.GetAxis("Mouse X") * RotationsSpeed;
            float v = transform.position.y;

            Quaternion camTurnAngle = Quaternion.AngleAxis(h, Vector3.up);

            Quaternion camTurnAngleY = Quaternion.AngleAxis(v, transform.right);

            Vector3 newCameraOffset = camTurnAngle * camTurnAngleY * _cameraOffset;

            // Limit camera pitch
            if (newCameraOffset.y < CameraPitchMin || newCameraOffset.y > CameraPitchMax)
            {
                newCameraOffset = camTurnAngle * _cameraOffset;
            }

            _cameraOffset = newCameraOffset;

        }

        Vector3 newPos = TargetTransform.position + _cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);

        if (LookAtTarget || RotateAroundTarget)
            transform.LookAt(TargetTransform);
    }
}
