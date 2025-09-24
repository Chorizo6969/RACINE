using System.Threading;
using UnityEngine;

public class BuildingUpgrade : MonoBehaviour
{
    private BuildingPanelHandler _panel;
    private BuildingBase _building;

    private void Awake()
    {
        TryGetComponent(out _panel);
    }

    public async void UpgradeBuilding()
    {
        _building = _panel.CurrentBuilding;
        if (_building == null || _building.Data.Upgrade == null || !ResourcesHandler.HasEnoughResources(_building.Data.Upgrade.Cost)) return;

        _panel.DetachPanel();
        BuildingData upgrade = _building.Data.Upgrade;

        BuildingManager.Instance.GridConstructor.GetCurrentCells(_building.Placement[0].CellPos, upgrade.Size, out var cells);
        if (cells.Count == 0 || !cells.TrueForAll(value => value.Building == null || value.Building == _building)) return; // If the upgrade can't be placed, the operation is cancelled.

        GameObject obj = Instantiate(upgrade.BuildingPrefab, _building.transform.position, Quaternion.identity);

        obj.name = upgrade.Name;

        BuildingBase newBuilding;
        obj.TryGetComponent(out newBuilding);
        newBuilding.Data = upgrade;

        Vector2Int previous = _building.Placement[0].CellPos;

        Destroy(_building.gameObject); // Destroys the previous building.

        CancellationTokenSource source = new();
        await BuildingManager.Instance.GridDragging.DragBuilding(source, newBuilding, true, previous);


    }
}
