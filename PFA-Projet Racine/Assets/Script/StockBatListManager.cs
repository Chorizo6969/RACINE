using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockBatListManager : MonoBehaviour
{
    public static StockBatListManager instance;

    public List<GameObject> listWoodStock;
    public List<GameObject> listWaterStock;
    public List <GameObject> listStoneStock;

    private void Awake()
    {
        instance = this;
    }

    public void AddObjectToList(GameObject obj, int listId)
    {
        switch (listId)
        {
            case 0:
                listWoodStock.Add(obj);
                break;
            case 1:
                listWaterStock.Add(obj);
                break;
            case 2:
                listStoneStock.Add(obj);
                break;
        }
    }
}