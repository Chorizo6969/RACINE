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

        // gives back half the building cost
        WorldResources gain = new();
        gain.Water = (int)Mathf.Ceil((float)_buildingPanelHandler.CurrentBuilding.Data.Cost.Water / 2f);
        gain.Rock = (int)Mathf.Ceil((float)_buildingPanelHandler.CurrentBuilding.Data.Cost.Rock / 2f);
        gain.Wood = (int)Mathf.Ceil((float)_buildingPanelHandler.CurrentBuilding.Data.Cost.Wood / 2f);
        ResourcesHandler.AddResources(gain);
    }
}
