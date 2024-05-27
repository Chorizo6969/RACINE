using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCanvas : MonoBehaviour
{
    public GameObject CanvasOptionPanel;

    [field : SerializeField] public GameObject HidePoint { get; private set; }

    public GameObject Building;

    public Material normal;

    public Material BuildingPlacableTrue;

    public Material BuildingPlacableFalse;

    [SerializeField] private int id;

    public bool placeOrNot;

    public int woodDestroyCost;
    public int stoneDestroyCost;

    private void Awake()
    {
        normal = Building.GetComponent<MeshRenderer>().material;
        if (id != 0)
        {
            IncrementHuman.instance.EditMaxHuman(5);
        }
        MaxBatPlacable.Instance.IncreaseActuBat(1);
    }

    public void PanelSetActive(bool enabled)
    {
        CanvasOptionPanel.SetActive(enabled);
    }

    public void FalseMat()
    {
        Building.GetComponent<MeshRenderer>().material = BuildingPlacableFalse;
    }

    public void TrueMat()
    {
        Building.GetComponent<MeshRenderer>().material = BuildingPlacableTrue;
    }

    public void NormalMat()
    {
        Building.GetComponent<MeshRenderer>().material = normal;
    }

    private void OnDestroy()
    {
        MaxBatPlacable.Instance.IncreaseActuBat(-1);
    }
}