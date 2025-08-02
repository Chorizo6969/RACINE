using TMPro;
using UnityEngine;

public class BuildingPanelHandler : MonoBehaviour
{
    #region Initialization

    [SerializeField]
    private RectTransform _buildingInfos;
    [SerializeField]
    private TextMeshProUGUI _buildingName;
    [SerializeField] 
    private TextMeshProUGUI _buildingDescription;

    public BuildingBase CurrentBuilding { get; set; }

    private void Start()
    {
        BuildingManager.Instance.Detector.OnBuildingDetected += GetBuildingInfos;
        BuildingManager.Instance.Detector.OnDetectionCancelled += DetachPanel;
    }

    #endregion

    private void GetBuildingInfos(BuildingBase building)
    {
        CurrentBuilding = building;
        UpdateBuildingInfos();

        _buildingInfos.transform.SetParent(CurrentBuilding.transform);
        _buildingInfos.transform.localPosition = Vector3.zero;

        _buildingInfos.gameObject.SetActive(true);
    }

    public void UpdateBuildingInfos()
    {
        _buildingName.text = CurrentBuilding.Data.Name;
        _buildingDescription.text = CurrentBuilding.Data.Description;
    }

    public void DetachPanel()
    {
        _buildingInfos.SetParent(null); // Detaches the panel from the building.
        _buildingInfos.gameObject.SetActive(false); // Hides the panel.
    }
}
