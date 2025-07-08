using System.Collections.Generic;
using UnityEngine;

public class BuildingPool : MonoBehaviour
{
    #region Initialization

    public static BuildingPool Instance { get; private set; }

    [SerializeField, Min(1), Tooltip("Amount of buildings to pool.")]
    private int _amount = 1;

    [SerializeField, Tooltip("The prefab to use to create the pool.")]
    private BuildingBase _buildingPrefab;

    private List<BuildingBase> _pool = new();

    private void Awake()
    {
        #region Singleton

        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;

        #endregion

        #region Object Pool

        if (_buildingPrefab == null) return;

        for(int i = 0; i < _amount; i++)
        {
            BuildingBase building = Instantiate(_buildingPrefab, transform);
            building.gameObject.SetActive(false);
            building.name = "Building"; // Set a default name for the building.
            _pool.Add(building);
        }

        #endregion
    }

    #endregion

    #region Object Pool Methods

    public BuildingBase GetFromPool(BuildingData data)
    {
        if(data == null) return null;
        if(_pool.Count == 0) return null;

        foreach(BuildingBase obj in _pool)
        {
            if (!obj.gameObject.activeInHierarchy)
            {
                _pool.Remove(obj);
                obj.gameObject.SetActive(true);

                // Building Update.
                obj.Data = data;
                obj.MeshFilter.mesh = data.Mesh;
                obj.gameObject.name = data.Name;

                return obj;
            }
        }

        return null;
    }

    public void BackToPool( BuildingBase building)
    {
        if (building == null) return;

        building.gameObject.SetActive(false);
        building.Data = null; // Reset the data to avoid confusion when reusing the object.
        building.name = "Building"; // Reset the name to a default value.

        _pool.Add(building);
    }

    #endregion
}
