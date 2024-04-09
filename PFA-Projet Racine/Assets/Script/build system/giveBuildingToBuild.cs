using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class giveBuildingToBuild : MonoBehaviour
{
    public GameObject building;

    public void OnClick()
    {
        GameObject _objectToGiveBuilding = FindAnyObjectByType<dragAndDropBuilding>().gameObject;
        _objectToGiveBuilding.GetComponent<dragAndDropBuilding>().BOUGE = building;
        Instantiate(building);
    }
}
