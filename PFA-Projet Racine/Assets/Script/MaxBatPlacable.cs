using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MaxBatPlacable : MonoBehaviour
{
    public static MaxBatPlacable Instance;

    //id = 0
    public int maxHouse;
    public int actuHouse;

    //id = 1
    public int maxBucheHouse;
    public int actuBucheHouse;

    //id = 2
    public int maxWaterHouse;
    public int actuWaterHouse;

    //id = 3
    public int maxStoneHouse;
    public int actuStoneHouse;

    //id = 4
    public int maxStockWood;
    public int actuStockWood;

    //id = 5
    public int maxStockWater;
    public int actuStockWater;

    //id = 6
    public int maxStockStone;
    public int actuStockStone;

    //id = 7
    public int maxTorche;
    public int actuTorche;

    //id = 8
    public int maxToilette;
    public int actuToilette;

    //id = 9
    public int maxField;
    public int actuField;

    //id = 10
    public int jukeBox;

    private void Awake()
    {
        Instance = this;
    }

    public void IncreaseMaxBat(int plusBat, int batId)
    {
        switch (batId)
        {
            case 0:
                maxHouse += plusBat;
                break;
            case 1:
                maxBucheHouse += plusBat;
                break;
            case 2:
                maxWaterHouse += plusBat;
                break;
            case 3:
                maxStoneHouse += plusBat;
                break;
            case 4:
                maxStockWood += plusBat;
                break;
            case 5:
                maxStockWater += plusBat;
                break;
            case 6:
                maxStockStone += plusBat;
                break;
            case 7:
                maxTorche += plusBat;
                break;
            case 8:
                maxToilette += plusBat;
                break;
            case 9:
                maxField += plusBat;
                break;
        }
    }

    public void IncreaseActuBat(int plusBat, int batId)
    {
        switch (batId)
        {
            case 0:
                actuHouse += plusBat;
                break;
            case 1:
                actuBucheHouse += plusBat;
                break;
            case 2:
                actuWaterHouse += plusBat;
                break;
            case 3:
                actuStoneHouse += plusBat;
                break;
            case 4:
                actuStockWood += plusBat;
                break;
            case 5:
                actuStockWater += plusBat;
                break;
            case 6:
                actuStockStone += plusBat;
                break;
            case 7:
                actuTorche += plusBat;
                break;
            case 8:
                actuToilette += plusBat;
                break;
            case 9:
                actuField += plusBat;
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