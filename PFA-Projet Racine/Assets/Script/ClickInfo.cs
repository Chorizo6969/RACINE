using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UIElements;

public class ClickInfo : MonoBehaviour
{
    public GameObject lastBat;
    public TextMeshProUGUI textMeshPro;

    public GameObject imageBat;
    public TextMeshProUGUI panelInfoNomBat;
    public TextMeshProUGUI panelDescriptionBat;

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
        if (lastBat.name == "Maison des Plongeurs")
        {
            lastBat.GetComponentInChildren<PlaceOuPasPlace>().ChangeBoxSizeUp();
        }
        dragAndDropBuilding.instance.BOUGE = lastBat;
        dragAndDropBuilding.instance.HasClickOnBuildingButtonInstance = true;
        lastBat.GetComponent<BuildingCanvas>().Building.GetComponent<PlaceOuPasPlace>().enabled = true;
    }

    public void OnClickInfo()
    {
        BuildingCanvas lastBatBuildingCanvas = lastBat.GetComponent<BuildingCanvas>();
        imageBat.GetComponent<Image>().image = lastBatBuildingCanvas.imageBat;
        panelInfoNomBat.text = lastBatBuildingCanvas.NomBat;
        panelDescriptionBat.text = lastBatBuildingCanvas.descriptionBat;
    }

    IEnumerator Attend()
    {
        yield return null;
        textMeshPro.text = lastBat.name;
    }
}