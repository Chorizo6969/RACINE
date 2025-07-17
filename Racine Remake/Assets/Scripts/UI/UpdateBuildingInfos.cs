using TMPro;
using UnityEngine;

public class UpdateBuildingInfos : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _buildingNameTMP;
    [SerializeField] 
    private TextMeshProUGUI _buildingDescriptionTMP;

    public void SetBuildingInfo(BuildingData data)
    {
        _buildingNameTMP.text = data.Name;
        _buildingDescriptionTMP.text = data.Description;
    }
}
