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

        // DEBUG : Initialize resources for testing purposes.
        WorldResources initialResources = new() { Wood = 50, Rock = 50, Water = 50 };
        ResourcesHandler.AddResources(initialResources);
    }

    private void UpdateResourcesDisplay(WorldResources resources)
    {
        _woodTMP.text = resources.Wood.ToString();
        _rockTMP.text = resources.Rock.ToString();
        _waterTMP.text = resources.Water.ToString();
    }
}
