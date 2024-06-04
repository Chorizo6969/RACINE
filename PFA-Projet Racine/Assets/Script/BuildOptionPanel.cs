using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BuildOptionPanel : MonoBehaviour
{
    public GameObject PANELRACINE;
    public GameObject PANEL;

    public void OnLeftClick(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            Physics.Raycast(ray, out hitInfo );
            if (hitInfo.collider != null && Jkh.Instance.CheckAllBool())
            {
                if (hitInfo.collider.CompareTag("RACINE"))
                {
                    PANELRACINE.SetActive(true);
                }
                else if (hitInfo.collider.CompareTag("building"))
                {
                    if (hitInfo.collider.GetComponentInParent<BuildingCanvas>().placeOrNot)
                    {
                        PANEL.SetActive(true);
                        PANEL.GetComponent<ClickInfo>().lastBat = hitInfo.collider.GetComponentInParent<BuildingCanvas>().gameObject;
                        
                    }
                }
            }
        }
    }
}