using System;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    #region Initialization

    #region Fields

    public Dictionary<Type, List<BuildingBase>> Buildings { get; set; } = new(); // Using IsSubclassOf() while looping through the keys can profide infos on a more general type.
    public static BuildingManager Instance { get; private set; }
    public BuildingDetector Detector { get; private set; }
    public GridConstructor GridConstructor { get; private set; }
    public BuildingConstructor BuildingConstructor { get; private set; }
    public GridDragging GridDragging { get; private set; }
    [field:SerializeField]
    public LayerMask GridLayer { get; private set; }// Layer mask to filter raycast hits to the grid layer.

    #endregion

    private void Awake()
    {
        #region Singleton Pattern

        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        else Instance = this;

        #endregion

        #region Components

        Detector = GetComponent<BuildingDetector>();
        GridConstructor = GetComponent<GridConstructor>();
        BuildingConstructor = GetComponent<BuildingConstructor>();
        GridDragging = GetComponent<GridDragging>();

        #endregion
    }

    #endregion

    #region Buildings Dictionary Update

    public void ReferenceBuilding(BuildingBase building)
    {
        List<BuildingBase> _typeBuildings = new();
        if (Buildings.ContainsKey(building.GetType())) Buildings.TryGetValue(building.GetType(), out _typeBuildings);
        
        _typeBuildings.Add(building);
        Buildings[building.GetType()] = _typeBuildings;
    }

    public void ResetBuilding(BuildingBase building)
    {
        List<BuildingBase> _typeBuildings = new();
        if (!Buildings.ContainsKey(building.GetType())) return;

        Buildings.TryGetValue(building.GetType(), out _typeBuildings);
        if (!_typeBuildings.Contains(building)) return;

        _typeBuildings.Remove(building);
        Buildings[building.GetType()] = _typeBuildings;
    }

    #endregion

}
