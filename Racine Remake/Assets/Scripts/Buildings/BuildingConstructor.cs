using System;
using UnityEngine;
using System.Collections.Generic;

public class BuildingConstructor : MonoBehaviour
{
    public event Action<BuildingBase> OnBuildingChosen;
    private GameObject _currentBuilding;

    public void ChooseBuilding(BuildingData data)
    {
        if (_currentBuilding != null || data == null) return;

        GameObject obj = Instantiate(data.BuildingPrefab, Vector3.zero, Quaternion.identity);
        obj.name = data.Name;

        BuildingBase building;
        obj.TryGetComponent(out building);

        building.Data = data;
        _currentBuilding = obj;

        OnBuildingChosen?.Invoke(building); // Notifies that a building has been chosen.
    }

    public bool BuyBuilding(bool creation, BuildingBase building, List<Cell> cells)
    {
        if (!creation && cells.Count > 0 && cells.TrueForAll(value => value.Building == null)) // Places the building without having to repay for it if it already has been placed.
        {
            building.Init();
            return true;
        }

        if (ResourcesHandler.HasEnoughResources(building.Data.Cost) && cells.Count > 0 && cells.TrueForAll(value => value.Building == null)) // Buys the building for the first time.
        {
            ResourcesHandler.RemoveResources(building.Data.Cost);
            building.Init();

            _currentBuilding = null;

            return true; // transaction can be made.
        }

        else return false; // you can't buy the building : cancellation.
    }
}
