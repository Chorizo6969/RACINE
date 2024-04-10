using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickFieldManager : MonoBehaviour
{
    [field : SerializeField] public GameObject HumanSeed {  get; set; }

    public void OnLeftClick(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            Physics.Raycast(ray, out hitInfo);
            
            if (hitInfo.collider != null && HumanSeed != null)
            {
                GameObject _touchedField = hitInfo.collider.gameObject;
                Plant _fieldPlantScript = _touchedField.GetComponent<Plant>();
                if (hitInfo.collider.CompareTag("field") && !_fieldPlantScript.IsPlanted && !GetComponent<dragAndDropBuilding>().hasClickOnBuildingButtonInstance)
                {
                    _fieldPlantScript.ThePlant = HumanSeed;
                    _fieldPlantScript.PlantField();
                    HumanSeed = null;
                }
            }
        }
    }
}