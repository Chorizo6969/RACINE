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

        // On crée l'upgrade du bâtiment
        BuildingData data = _buildingPanelHandler.CurrentBuilding.Data.Upgrade;

        GameObject obj = Instantiate(data.BuildingPrefab, pos, Quaternion.identity);
        obj.name = data.Name;

        BuildingBase building;
        obj.TryGetComponent(out building);

        building.Data = data;

        // temporaire ça hein
        Vector2Int newPos = new Vector2Int((int)(building.transform.position.x + 0.5f), (int)building.transform.position.z);

        BuildingManager.Instance.GridConstructor.Grid.TryGetValue(newPos, out Cell cell);
        building.Placement.Add(cell);

        BuildingManager.Instance.GridDragging.PlaceBuilding(building);
        //BuildingManager.Instance.GridDragging.StopDragging();

        Destroy(_buildingPanelHandler.CurrentBuilding.gameObject);
        _buildingPanelHandler.CurrentBuilding = building;
        building.Init();

        //if (BuildingManager.Instance.BuildingConstructor.BuyBuilding(building.Placement.Count == 0, building, _buildingCells)) // If the building can be bought and placed.
        // condition pas passée pour l'upgrade, dans GridDragging ligne 110

        // APRES CA, BuildingPanelHandler marche pu
    }
}
