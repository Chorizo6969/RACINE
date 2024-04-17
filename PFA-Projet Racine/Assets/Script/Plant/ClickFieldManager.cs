using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Script qui gère les cliques en rapport avec les champs
/// </summary>
public class ClickFieldManager : MonoBehaviour
{
    /// <summary>
    /// Référence de la graine de l'humain plante qui va être planter
    /// </summary>
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
                
                if (hitInfo.collider.CompareTag("field") && !_fieldPlantScript.IsWatered && !_fieldPlantScript.IsPlanted && !GetComponent<dragAndDropBuilding>().HasClickOnBuildingButtonInstance && HumanSeed != null)
                {
                    _fieldPlantScript.ThePlant = HumanSeed;
                    _fieldPlantScript.PlantField();
                    HumanSeed = null;
                }
                else if (hitInfo.collider.CompareTag("field") && !_fieldPlantScript.IsWatered && _fieldPlantScript.IsPlanted && !GetComponent<dragAndDropBuilding>().HasClickOnBuildingButtonInstance)
                {
                    _fieldPlantScript.WateringField();
                }
                else if (hitInfo.collider.CompareTag("field") && _fieldPlantScript.IsPlanted && !GetComponent<dragAndDropBuilding>().HasClickOnBuildingButtonInstance && _fieldPlantScript._progressCircle.GetComponentInChildren<Fill>().IsFillAmountFull)
                {
                    _fieldPlantScript.HarvestField();
                }
            }
        }
    }
}