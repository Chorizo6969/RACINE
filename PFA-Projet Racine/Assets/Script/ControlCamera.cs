using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlCamera : MonoBehaviour
{
    public Camera Camera;
    public Transform CameraTransform;

    private void Start()
    {
        CameraTransform = transform;
    }

    public void OnZoomP(InputAction.CallbackContext _context)
    {
        if (Camera.GetComponent<Camera>().orthographicSize >= 1.5f)
        {
            Camera.GetComponent<Camera>().orthographicSize -= 0.06f;
            if (Camera.GetComponent<Camera>().orthographicSize <= 1.5f)
            {
                Camera.GetComponent<Camera>().orthographicSize = 1.5f;
            }
        }
    }

    public void OnZoomM(InputAction.CallbackContext _context)
    {
        if (Camera.GetComponent<Camera>().orthographicSize <= 5f)
        {
            Camera.GetComponent<Camera>().orthographicSize += 0.06f;
            if (Camera.GetComponent<Camera>().orthographicSize >= 5f)
            {
                Camera.GetComponent<Camera>().orthographicSize = 5f;
            }
        }
    }


}
