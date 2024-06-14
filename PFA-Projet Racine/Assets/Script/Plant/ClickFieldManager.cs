using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.VFX;

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
                    GiveRefToField.instance.GiveRefPasTuple(_touchedField, GetComponent<Spawn>().HumanPrefab, GetComponent<Spawn>().PrefabButtonBucheron, GetComponent<Spawn>().PrefabButtonAquaman, GetComponent<Spawn>().PrefabButtonMineur, GetComponent<Spawn>().Parent, GetComponent<Spawn>()._visualEffectEau1, GetComponent<Spawn>()._visualEffectEau2);
                    
                    HumanSeed = null;
                }
                else if (hitInfo.collider.CompareTag("field") && !_fieldPlantScript.IsWatered && _fieldPlantScript.IsPlanted && !GetComponent<dragAndDropBuilding>().HasClickOnBuildingButtonInstance)
                {
                    _fieldPlantScript.WateringField();
                }
                else if (hitInfo.collider.CompareTag("field") && _fieldPlantScript.IsPlanted && !GetComponent<dragAndDropBuilding>().HasClickOnBuildingButtonInstance && _fieldPlantScript._progressCircle.GetComponentInChildren<Fill>().IsFillAmountFull && IncrementHuman.instance._count < IncrementHuman.instance._maxHuman)
                {
                    if (_fieldPlantScript.ThePlant.GetComponent<PrePlantJob>().Work == "Bucheron" && IncrementHuman.instance._countBucheron < IncrementHuman.instance._maxBucheron)
                    {
                        _fieldPlantScript.HarvestField();
                    }
                    else if (_fieldPlantScript.ThePlant.GetComponent<PrePlantJob>().Work == "Mineur" && IncrementHuman.instance._countStoneMan < IncrementHuman.instance._maxStoneMan)
                    {
                        _fieldPlantScript.HarvestField();
                    }
                    else if (_fieldPlantScript.ThePlant.GetComponent<PrePlantJob>().Work == "Eau" && IncrementHuman.instance._countAquaman < IncrementHuman.instance._maxAquaman)
                    {
                        _fieldPlantScript.HarvestField();
                    }
                }
            }
        }
    }
}