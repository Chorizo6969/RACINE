using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickInfo : MonoBehaviour
{
    public GameObject lastBat;

    public void OnClickDestroy()
    {
        RessourceManager.Instance.EditStoneAmount(lastBat.GetComponent<BuildingCanvas>().woodDestroyCost);
        RessourceManager.Instance.EditStoneAmount(lastBat.GetComponent<BuildingCanvas>().stoneDestroyCost);
        Destroy(lastBat);
    }

    public void OnClickMove()
    {
        dragAndDropBuilding.instance.BOUGE = lastBat;
        dragAndDropBuilding.instance.HasClickOnBuildingButtonInstance = true;
        lastBat.GetComponent<BuildingCanvas>().Building.GetComponent<PlaceOuPasPlace>().enabled = true;
    }

    public void OnClickInfo()
    {
        Debug.Log("BWARG");
    }
}