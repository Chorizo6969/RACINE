using TMPro;
using UnityEngine;

public class ResourcesDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _woodTMP;
    [SerializeField]
    private TextMeshProUGUI _rockTMP;
    [SerializeField]
    private TextMeshProUGUI _waterTMP;

    private void Awake()
    {
        ResourcesHandler.OnResourcesUpdate += UpdateResourcesDisplay;
    }

    private void UpdateResourcesDisplay(WorldResources resources)
    {
        _woodTMP.text = resources.Wood.ToString();
        _rockTMP.text = resources.Rock.ToString();
        _waterTMP.text = resources.Water.ToString();
    }
}
