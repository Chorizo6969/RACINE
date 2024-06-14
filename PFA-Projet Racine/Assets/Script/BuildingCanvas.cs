using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BuildingCanvas : MonoBehaviour
{
    public GameObject CanvasOptionPanel;

    [field : SerializeField] public GameObject HidePoint { get; private set; }

    public GameObject Building;

    public Material normal;

    public Material BuildingPlacableTrue;

    public Material BuildingPlacableFalse;

    [field : SerializeField] public int id {  get; private set; }

    public bool placeOrNot;

    public int woodDestroyCost;
    public int stoneDestroyCost;

    public bool FirstPlacement = true;

    private static bool _tuto = true;
    public static bool _tuto2LeRetourDuJedi = true;

    public GameObject EZTimeBuildSystem;
    public GameObject TKTJeGere;
    public GameObject Canvas;

    public Sprite imageBat;
    public string NomBat;
    public string descriptionBat;

    private void Awake()
    {
        normal = Building.GetComponent<MeshRenderer>().material;
    }
    public void DropBuilding()
    {
        woodDestroyCost = GetComponent<BuildingCost>().WoodCost / 2;
        stoneDestroyCost = GetComponent<BuildingCost>().StoneCost / 2;

        if (FirstPlacement)
        {
            if (id == 0)
            {
                IncrementHuman.instance.EditMaxHuman(5);
            }
            MaxBatPlacable.Instance.IncreaseActuBat(1, id);

            GetComponent<BuildingCost>().BuyBuilding();

            EZTimeBuildSystem.SetActive(false);
            TKTJeGere.SetActive(true);
            Canvas.SetActive(true);

            PlayASound.Instance.PlaySound();

            //C'EST ICI MATÉO 
            //ps : J'TE BOUFFE LE CUL MATÉOOOOOOOOOOOOOO signé : Yael
        }

        switch (id)
        {
            case 0:
                gameObject.name = "Maison";
                break;
            case 1:
                gameObject.name = "Maison de Bucheron";
                if (_tuto2LeRetourDuJedi == true)
                {
                    _tuto2LeRetourDuJedi = false;
                    Leroidesdéchets.instance.Incremente();
                    Destroy(Leroidesdéchets.instance.gameObject, 1);
                }
                break;
            case 2:
                gameObject.name = "Maison des Plongeurs";
                break;
            case 3:
                gameObject.name = "Maison des Mineurs";
                break;
            case 4:
                gameObject.name = "Reserve de bois";
                GetComponent<AddStock>().DropBuilding();
                break;
            case 5:
                gameObject.name = "Reserve d'Eau";
                GetComponent<AddStock>().DropBuilding();
                break;
            case 6:
                gameObject.name = "Reserve de Pierre";
                GetComponent<AddStock>().DropBuilding();
                break;
            case 7:
                gameObject.name = "Torche";
                break;
            case 8:
                gameObject.name = "Toilette";
                break;
            case 9:
                gameObject.name = "Champ";
                if (_tuto == true)
                {
                    _tuto = false;
                    Leroidesdéchets.instance.Incremente();
                }
                break;
            case 10:
                gameObject.name = "JukeBox";
                break;
        }
        NomBat = gameObject.name;


        FirstPlacement = false;
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
        if (FirstPlacement) return;
        MaxBatPlacable.Instance.IncreaseActuBat(-1, id);
    }
}