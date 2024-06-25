using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class MaxBatPlacable : MonoBehaviour
{
    public static MaxBatPlacable Instance;

    [Header("Maison id = 0")]
    //id = 0
    public int actuHouse;
    public int maxHouse;
    public TextMeshProUGUI HouseText;
    public TextMeshProUGUI MaxHouseText;

    [Header("Maison bucheron id = 1")]
    //id = 1
    public int actuBucheHouse;
    public int maxBucheHouse;
    public TextMeshProUGUI BucheHouseText;
    public TextMeshProUGUI MaxBucheHouseText;

    [Header("Maison pecheur id = 2")]
    //id = 2
    public int actuWaterHouse;
    public int maxWaterHouse;
    public TextMeshProUGUI WaterHouseText;
    public TextMeshProUGUI MaxWaterHouseText;

    [Header("Maison mineur id = 3")]
    //id = 3
    public int actuStoneHouse;
    public int maxStoneHouse;
    public TextMeshProUGUI StoneHouseText;
    public TextMeshProUGUI MaxStoneHouseText;

    [Header("Stock bois id = 4")]
    //id = 4
    public int actuStockWood;
    public int maxStockWood;
    public TextMeshProUGUI StockWoodText;
    public TextMeshProUGUI MaxStockWoodText;

    [Header("Stock eau id = 5")]
    //id = 5
    public int actuStockWater;
    public int maxStockWater;
    public TextMeshProUGUI StockWaterText;
    public TextMeshProUGUI MaxStockWaterText;

    [Header("Stock pierre id = 6")]
    //id = 6
    public int actuStockStone;
    public int maxStockStone;
    public TextMeshProUGUI StockStoneText;
    public TextMeshProUGUI MaxStockStoneText;

    [Header("Torche id = 7")]
    //id = 7
    public int actuTorche;
    public int maxTorche;
    public TextMeshProUGUI TorcheText;
    public TextMeshProUGUI MaxTorcheText;

    [Header("Toilettes id = 8")]
    //id = 8
    public int actuToilette;
    public int maxToilette;
    public TextMeshProUGUI ToiletteText;
    public TextMeshProUGUI MaxToiletteText;

    [Header("Champ id = 9")]
    //id = 9
    public int actuField;
    public int maxField;
    public TextMeshProUGUI FieldText;
    public TextMeshProUGUI MaxFieldText;

    [Header("JukeBox id = 10")]
    //id = 10
    public int jukeBox;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        HouseText.text          = actuHouse.ToString();
        MaxHouseText.text       = maxHouse.ToString();
        BucheHouseText.text     = actuBucheHouse.ToString();
        MaxBucheHouseText.text  = maxBucheHouse.ToString();
        WaterHouseText.text     = actuWaterHouse.ToString();
        MaxWaterHouseText.text  = maxWaterHouse.ToString();
        StoneHouseText.text     = actuStockStone.ToString();
        MaxStoneHouseText.text  = maxStoneHouse.ToString();
        StockWoodText.text      = actuStockWood.ToString();
        MaxStockWoodText.text   = maxStockWood.ToString();
        StockWaterText.text     = actuStockWater.ToString();
        MaxStockWaterText.text  = maxStockWater.ToString();
        StockStoneText.text     = actuStockStone.ToString();
        MaxStockStoneText.text  = maxStockStone.ToString();
        TorcheText.text         = actuTorche.ToString();
        MaxTorcheText.text      = maxTorche.ToString();
        ToiletteText.text       = actuToilette.ToString();
        MaxToiletteText.text    = maxToilette.ToString();
        FieldText.text          = actuField.ToString();
        MaxFieldText.text       = maxField.ToString();
    }

    public void IncreaseMaxBat(int plusBat, int batId)
    {
        switch (batId)
        {
            case 0:
                maxHouse += plusBat;
                MaxHouseText.text = maxHouse.ToString();
                break;
            case 1:
                maxBucheHouse += plusBat;
                MaxBucheHouseText.text = maxBucheHouse.ToString();
                break;
            case 2:
                maxWaterHouse += plusBat;
                MaxWaterHouseText.text = maxWaterHouse.ToString();
                break;
            case 3:
                maxStoneHouse += plusBat;
                MaxStoneHouseText.text = maxStoneHouse.ToString();
                break;
            case 4:
                maxStockWood += plusBat;
                MaxStockWoodText.text = maxStockWood.ToString();
                break;
            case 5:
                maxStockWater += plusBat;
                MaxStockWaterText.text = maxStockWater.ToString();
                break;
            case 6:
                maxStockStone += plusBat;
                MaxStockStoneText.text = maxStockStone.ToString();
                break;
            case 7:
                maxTorche += plusBat;
                MaxTorcheText.text = maxTorche.ToString();
                break;
            case 8:
                maxToilette += plusBat;
                MaxToiletteText.text = maxToilette.ToString();
                break;
            case 9:
                maxField += plusBat;
                MaxFieldText.text = maxField.ToString();
                break;
        }
    }

    public void IncreaseActuBat(int plusBat, int batId)
    {
        switch (batId)
        {
            case 0:
                actuHouse += plusBat;
                HouseText.text = actuHouse.ToString();
                break;
            case 1:
                actuBucheHouse += plusBat;
                BucheHouseText.text = actuBucheHouse.ToString();
                break;
            case 2:
                actuWaterHouse += plusBat;
                WaterHouseText.text = actuWaterHouse.ToString();
                break;
            case 3:
                actuStoneHouse += plusBat;
                StoneHouseText.text = actuStoneHouse.ToString();
                break;
            case 4:
                actuStockWood += plusBat;
                StockWoodText.text = actuStockWood.ToString();
                break;
            case 5:
                actuStockWater += plusBat;
                StockWaterText.text = actuStockWater.ToString();
                break;
            case 6:
                actuStockStone += plusBat;
                StockStoneText.text = actuStockStone.ToString();
                break;
            case 7:
                actuTorche += plusBat;
                TorcheText.text = actuTorche.ToString();
                break;
            case 8:
                actuToilette += plusBat;
                ToiletteText.text = actuToilette.ToString();
                break;
            case 9:
                actuField += plusBat;
                FieldText.text = actuField.ToString();
                break;
            case 10:
                jukeBox++;
                break;
        }
    }

    public bool CheckIfBatIsPlacable(int batId)
    {
        switch (batId)
        {
            case 0:
                if (maxHouse > actuHouse) 
                {
                    return true;
                }
                break;
            case 1:
                if (maxBucheHouse > actuBucheHouse) 
                {
                    return true;
                }
                break;
            case 2:
                if (maxWaterHouse > actuWaterHouse)
                {
                    return true;
                }
                break;
            case 3:
                if (maxStoneHouse > actuStoneHouse)
                {
                    return true;
                }
                break;
            case 4:
                if (maxStockWood > actuStockWood)
                {
                    return true;
                }
                break;
            case 5:
                if (maxStockWater > actuStockWater)
                {
                    return true;
                }
                break;
            case 6:
                if (maxStockStone > actuStockStone)
                {
                    return true;
                }
                break;
            case 7:
                if (maxTorche > actuTorche)
                {
                    return true;
                }
                break;
            case 8:
                if (maxToilette > actuToilette)
                {
                    return true;
                }
                break;
            case 9:
                if (maxField > actuField)
                {
                    return true;
                }
                break;
            case 10:
                if (jukeBox == 0)
                {
                    return true;
                }
                break;
        }
        return false;
    }
}