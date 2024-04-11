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
            
            if (hitInfo.collider != null)
            {
                GameObject _touchedField = hitInfo.collider.gameObject;
                Field _fieldPlantScript = _touchedField.GetComponent<Field>();
                if (hitInfo.collider.CompareTag("field") && !_fieldPlantScript.IsWatered && !_fieldPlantScript.IsPlanted && !GetComponent<dragAndDropBuilding>().hasClickOnBuildingButtonInstance && HumanSeed != null)
                {
                    _fieldPlantScript.ThePlant = HumanSeed;
                    _fieldPlantScript.PlantField();
                    HumanSeed = null;
                    Debug.Log("Ton pere");
                }
                else if (hitInfo.collider.CompareTag("field") && !_fieldPlantScript.IsWatered && _fieldPlantScript.IsPlanted && !GetComponent<dragAndDropBuilding>().hasClickOnBuildingButtonInstance)
                {
                    _fieldPlantScript.WateringField();
                    Debug.Log("Ta mere");
                }
                else if (hitInfo.collider.CompareTag("field") && _fieldPlantScript.IsPlanted && !GetComponent<dragAndDropBuilding>().hasClickOnBuildingButtonInstance)
                {
                    Debug.Log("Ta soeur");
                }
            }
        }
    }
}