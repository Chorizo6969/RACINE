using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BuildOptionPanel : MonoBehaviour
{
    public GameObject PANELRACINE;
    public void OnLeftClick(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            Physics.Raycast(ray, out hitInfo);
            if (hitInfo.collider != null)
            {
                if (hitInfo.collider.CompareTag("RACINE"))
                {
                    PANELRACINE.SetActive(true);
                }
            }
        }
    }
}