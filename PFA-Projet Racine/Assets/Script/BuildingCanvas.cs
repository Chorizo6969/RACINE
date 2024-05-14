using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCanvas : MonoBehaviour
{
    [SerializeField] private GameObject CanvasOptionPanel;

    [field : SerializeField] public GameObject HidePoint { get; private set; }

    public GameObject Building;

    public Material normal;

    public Material BuildingPlacableTrue;

    public Material BuildingPlacableFalse;

    private PlaceOuPasPlace _placeOuPasPlace;

    private void Start()
    {
        normal = Building.GetComponent<MeshRenderer>().material;
    }

    public void PanelSetActive(bool enabled)
    {
        CanvasOptionPanel.SetActive(enabled);
    }
}