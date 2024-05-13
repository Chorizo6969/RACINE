using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCanvas : MonoBehaviour
{
    [SerializeField] private GameObject CanvasOptionPanel;

    [field : SerializeField] public GameObject HidePoint {  get; private set; }

    public GameObject BuildingGroup;

    public GameObject Building;

    public GameObject BuildingPlacableTrue;

    public GameObject BuildingPlacableFalse;

    public void PanelSetActive(bool enabled)
    {
        CanvasOptionPanel.SetActive(enabled);
    }
}