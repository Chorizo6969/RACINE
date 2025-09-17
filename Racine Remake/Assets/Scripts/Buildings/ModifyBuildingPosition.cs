using UnityEngine;

public class ModifyBuildingPosition : MonoBehaviour
{
    private BuildingPanelHandler _buildingPanelHandler;

    private void Awake()
    {
        TryGetComponent(out _buildingPanelHandler);
    }

    public void ModifyCurrentBuildingPosition()
    {
        _buildingPanelHandler.DetachPanel();
        BuildingManager.Instance.GridConstructor.ActivateGrid(true);
        BuildingManager.Instance.GridDragging.StartDraggingMethod(_buildingPanelHandler.CurrentBuilding);
    }
}
