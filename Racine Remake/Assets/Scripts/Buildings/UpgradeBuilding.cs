using UnityEngine;
using UnityEngine.UIElements;

public class UpgradeBuilding : MonoBehaviour
{
    #region Initialization

    private BuildingPanelHandler _buildingPanelHandler;

    private void Awake()
    {
        TryGetComponent(out _buildingPanelHandler);
    }

    #endregion

    public void UpgradeCurrrentBuilding()
    {
        if (!_buildingPanelHandler.CurrentBuilding.Data.Upgrade) return;
        if (!ResourcesHandler.HasEnoughResources(_buildingPanelHandler.CurrentBuilding.Data.Upgrade.Cost)) return;

        Vector3 pos = _buildingPanelHandler.CurrentBuilding.transform.position;

        GameObject obj = Instantiate(_buildingPanelHandler.CurrentBuilding.Data.Upgrade.BuildingPrefab, pos, Quaternion.identity);
        obj.TryGetComponent(out BuildingBase building);
        BuildingManager.Instance.GridDragging.PlaceBuilding(building);
        //BuildingManager.Instance.GridDragging.StopDragging();

        Destroy(_buildingPanelHandler.CurrentBuilding.gameObject);
        _buildingPanelHandler.CurrentBuilding = building;
        
        //building.Init();
        // APRES CA, BuildingPanelHandler marche pu
    }
}
