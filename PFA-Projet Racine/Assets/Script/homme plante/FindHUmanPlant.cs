using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FindHUmanPlant : MonoBehaviour
{
    public void OnLeftClickOnHumanPlant(InputAction.CallbackContext _callbackContext)
    {
        if (_callbackContext.started)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            Physics.Raycast(ray, out hitInfo);
            if (hitInfo.collider != null)
            {
                if (hitInfo.collider.gameObject.CompareTag("humanPlant"))
                {
                    GameObject _touchedPlant = hitInfo.collider.gameObject;
                    if (_touchedPlant.GetComponent<HideNSeek>().IsHiding)
                    {
                        _touchedPlant.GetComponent<HideNSeek>()._startHiding = true;
                        _touchedPlant.GetComponent<NewRandomPos>().ParticleSystemSLEEP.Stop();
                    }
                    HumanSound.instance.Verification(hitInfo.collider.gameObject);
                }
            }
        }
    }
}