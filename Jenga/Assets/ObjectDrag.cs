using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDrag : MonoBehaviour
{
    private Camera _mainCam;
    private Vector3 diff;

    private void Start()
    {
        _mainCam = Camera.main;

    }
    private void OnMouseDown()
    {
        diff = Input.mousePosition - _mainCam.WorldToScreenPoint(transform.position);
    }
    private void OnMouseDrag()
    {
        transform.position = _mainCam.ScreenToWorldPoint(Input.mousePosition - diff);
    }
}
