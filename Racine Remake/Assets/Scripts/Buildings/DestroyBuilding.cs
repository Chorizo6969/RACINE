using UnityEngine;

public class DestroyBuilding : MonoBehaviour
{
    #region Initialization

    private BuildingPanelHandler _buildingPanelHandler;

    private void Awake()
    {
        TryGetComponent(out _buildingPanelHandler);
    }

    #endregion

    public void DestroyCurrentBuilding()
    {
        _buildingPanelHandler.DetachPanel();
        Destroy(_buildingPanelHandler.CurrentBuilding.gameObject);
    }
}
