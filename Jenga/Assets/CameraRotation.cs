using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform _target;
    private Vector3 _cameraOffSet;
    [Range(0.01f, 1.0f)]
    public float smoothFactor = 0.5f;
    public bool LookAtTarget = false;
    public bool RotateArountTarget = true;
    public float RotationSpeed = 5.0f;

    private void Start()
    {
        _cameraOffSet = transform.position - _target.position;

    }
    private void LateUpdate()
    {
        if (RotateArountTarget)
        {
            Quaternion camTurnAngel
                = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationSpeed, Vector3.up);
            _cameraOffSet = camTurnAngel * _cameraOffSet;
        }
        Vector3 newPos = _target.position + _cameraOffSet;
        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);

        if (LookAtTarget || RotateArountTarget)
        {
            transform.LookAt(_target);
        }
    }
}
