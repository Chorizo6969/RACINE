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
        //if (ResourcesHandler.HasEnoughResources(_buildingPanelHandler.CurrentBuilding.Data.Cost)) // au cas o� d�placer a un co�t
        _buildingPanelHandler.DetachPanel();
        BuildingManager.Instance.GridConstructor.ActivateGrid(true);
        BuildingManager.Instance.GridDragging.StartDraggingMethod(_buildingPanelHandler.CurrentBuilding);
    }
}
