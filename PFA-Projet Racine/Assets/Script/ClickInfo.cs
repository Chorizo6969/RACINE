using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class ClickInfo : MonoBehaviour
{
    public GameObject lastBat;
    public TextMeshProUGUI textMeshPro;

    private void OnEnable()
    {
        StartCoroutine(Attend());
    }

    public void OnClickDestroy()
    {
        RessourceManager.Instance.EditStoneAmount(lastBat.GetComponent<BuildingCanvas>().woodDestroyCost);
        RessourceManager.Instance.EditStoneAmount(lastBat.GetComponent<BuildingCanvas>().stoneDestroyCost);
        Destroy(lastBat);
        lastBat = null;
        gameObject.SetActive(false);
    }

    public void OnClickMove()
    {
        if (lastBat.name == "4Maison Water Man(Clone)")
        {
            lastBat.GetComponentInChildren<PlaceOuPasPlace>().ChangeBoxSizeUp();
        }
        dragAndDropBuilding.instance.BOUGE = lastBat;
        dragAndDropBuilding.instance.HasClickOnBuildingButtonInstance = true;
        lastBat.GetComponent<BuildingCanvas>().Building.GetComponent<PlaceOuPasPlace>().enabled = true;
    }

    public void OnClickInfo()
    {
        Debug.Log("BWARG");
    }

    IEnumerator Attend()
    {
        yield return null;
        textMeshPro.text = lastBat.name;
    }
}