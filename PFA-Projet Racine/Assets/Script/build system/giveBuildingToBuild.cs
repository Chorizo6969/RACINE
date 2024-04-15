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

    public void OnClick()
    {
        if (GetComponent<BuildingCost>().PlayerRessourceManager.CheckIfCanBuild(GetComponent<BuildingCost>().WoodCost, GetComponent<BuildingCost>().StoneCost))
        {
            GetComponent<BuildingCost>().BuyBuilding();
            GameObject _objectToGiveBuilding = FindAnyObjectByType<dragAndDropBuilding>().gameObject;
            GameObject newBuilding = Instantiate(building);
            _objectToGiveBuilding.GetComponent<dragAndDropBuilding>().BOUGE = newBuilding;
            _objectToGiveBuilding.GetComponent<dragAndDropBuilding>().ClickOnButtonInstancier();
        }
    }
}