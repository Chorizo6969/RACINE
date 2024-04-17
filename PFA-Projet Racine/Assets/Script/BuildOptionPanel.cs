using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BuildOptionPanel : MonoBehaviour
{
    private GameObject _lastClickBuilding;
    public void OnRightClick(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            Physics.Raycast(ray, out hitInfo);
            if (hitInfo.collider != null)
            {
                GameObject collider = hitInfo.collider.gameObject;
                if (hitInfo.collider.CompareTag("building") || hitInfo.collider.CompareTag("field"))
                {
                    _lastClickBuilding = collider;
                    collider.GetComponent<BuildingCanvas>().PanelSetActive(true);
                }
                else
                {
                    _lastClickBuilding.GetComponent<BuildingCanvas>().PanelSetActive(false);
                    _lastClickBuilding = null;
                }
            }
            
        }
    }
}
