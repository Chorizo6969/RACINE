using System.Collections.Generic;
using UnityEngine;

public class BuildingPool : MonoBehaviour
{
    #region Initialization

    [SerializeField]
    private BuildingMain _objectToPool;
    [SerializeField]
    private int _amountToPool;

    private List<BuildingMain> _pool = new();

    private void Start()
    {
        for (int i = 0; i < _amountToPool; i++)
        {
            BuildingMain building = Instantiate(_objectToPool, BuildingManager.Instance.GridPlacing.ConstructionTilemap.transform);

            // Adjust the rotation of the building to match the grid layout.
            var buildingRot = building.transform.rotation;
            buildingRot.x -= BuildingManager.Instance.GridPlacing.GridLayout.transform.rotation.x;
            building.transform.rotation = buildingRot;

            building.gameObject.SetActive(false);
            _pool.Add(building);
        }
    }

    #endregion

    #region ObjectPool

    public BuildingMain GetFromPool(BuildingData data)
    {
        if (_pool == null || _pool.Count <= 0) return null;

        BuildingMain building = _pool[0];
        _pool.RemoveAt(0);
        building.gameObject.SetActive(true);
        UpdateBuildingInfos(data, building);

        return building;
    }

    public void ReturnToPool(BuildingMain building)
    {
        if (_pool == null) return;

        building.gameObject.SetActive(false);
        building.name = _objectToPool.name;
        _pool.Add(building);
    }

    #endregion

    public void UpdateBuildingInfos(BuildingData data, BuildingMain building)
    {
        building.Building = BuildingManager.Instance.BuildingTypes[data.Type];
        building.Data = data;
        building.name = data.Name;
        building.Filter.mesh = data.Mesh;

        BoundsInt area = building.Area;
        area.size = new Vector3Int(data.Size.x, data.Size.y, 1);
        building.Area = area;

        building.Building.Effect();
    }
}
