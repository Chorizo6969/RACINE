using UnityEngine;

/// <summary>
/// Attribut un batiment quand on clique sur un bouton
/// </summary>
public class GiveBuildingToBuild : MonoBehaviour
{
    /// <summary>
    /// Batiment qui va être posé
    /// </summary>
    public GameObject building;

    [SerializeField] private GameObject HidePointListOwner;

    public GameObject _objectToGiveBuilding;

    public GameObject BuildingPanelTuto;

    private void Start()
    {
        _objectToGiveBuilding = dragAndDropBuilding.instance.gameObject;
    }

    public void OnClick()
    {
        /*Debug.Log(GetComponent<BuildingCost>());
        Debug.Log(GetComponent<BuildingCost>().PlayerRessourceManager);
        Debug.Log(MaxBatPlacable.Instance);*/


        if (/*GetComponent<BuildingCost>().PlayerRessourceManager*/ RessourceManager.Instance.CheckIfCanBuild(GetComponent<BuildingCost>().WoodCost, GetComponent<BuildingCost>().StoneCost, 0) && MaxBatPlacable.Instance.CheckIfBatIsPlacable(building.GetComponent<BuildingCanvas>().id) && _objectToGiveBuilding.GetComponent<dragAndDropBuilding>().BOUGE == null)
        {
            UIManager.Instance.ActivationUi();
            GameObject newBuilding = Instantiate(building);
            _objectToGiveBuilding.GetComponent<dragAndDropBuilding>().BOUGE = newBuilding;
            _objectToGiveBuilding.GetComponent<dragAndDropBuilding>().ClickOnButtonInstancier();
            if (newBuilding.GetComponent<BuildingCanvas>().HidePoint != null)
            {
                HidePointListOwner.GetComponent<HidePointList>().AddObjectInList(newBuilding.GetComponent<BuildingCanvas>().HidePoint);
            }
            BuildingPanelTuto.SetActive(true);
        }
    }
}