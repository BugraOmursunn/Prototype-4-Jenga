using UnityEngine;
using System.Collections;


public class cameraorbit : MonoBehaviour
{

    public Transform target;
    public VehicleCameraController hedef;
    public float distance = 10.0f;
    public bool pressing;
    public float xSpeed = 250f;
    public float ySpeed = 120f;
    public float orthoZoomSpeed;
    public float yMinLimit = -20f;
    public float yMaxLimit = 80f;
    public float maxdistance, mindistance;
    private float x = 0f;
    private float y = 0f;



    void Start()
    {

        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        // Make the rigid body not change rotation
        if (GetComponent<Rigidbody>())
            GetComponent<Rigidbody>().freezeRotation = true;

    }

    // float minFov = 15f;
    // float maxFov = 90f;
    // float sensitivity = 10f;
    // void Update()
    // {

    //     float fov = Camera.main.fieldOfView;
    //     fov += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
    //     fov = Mathf.Clamp(fov, minFov, maxFov);
    //     Camera.main.fieldOfView = fov;
    // }




    public void PointerEnter()
    {
        pressing = true;
    }
    public void PointerExit()
    {
        pressing = false;
    }


    public void Drag()
    {
        x = Input.GetAxis("Mouse X") * xSpeed * 0.02f;
        y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
        y = ClampAngle(y, yMinLimit, yMaxLimit);
        target.Rotate(0, x, 0);
        GetComponent<VehicleCameraController>().smoothFollowSettings.height = y;
    }
    static float ClampAngle(float angle, float min, float max)
    {

        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);

    }


}
