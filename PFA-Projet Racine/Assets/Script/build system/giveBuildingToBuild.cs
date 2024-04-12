using UnityEngine;

public class giveBuildingToBuild : MonoBehaviour
{
    public GameObject building;

    public void OnClick()
    {
        GameObject _objectToGiveBuilding = FindAnyObjectByType<dragAndDropBuilding>().gameObject;
        GameObject newBuilding = Instantiate(building);
        _objectToGiveBuilding.GetComponent<dragAndDropBuilding>().BOUGE = newBuilding;
        _objectToGiveBuilding.GetComponent<dragAndDropBuilding>().ClickOnButtonInstancier();
    }
}