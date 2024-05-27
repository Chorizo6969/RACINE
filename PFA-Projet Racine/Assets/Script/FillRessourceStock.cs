using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillRessourceStock : MonoBehaviour
{
    public GameObject Stock1;
    public GameObject Stock2;
    public GameObject Stock3;
    public GameObject Stock4;
    public GameObject Stock5;

    public int id;

    private void Start()
    {

        switch (id)
        {
            case 0:
                StockBatListManager.instance.AddObjectToList(gameObject, 0);
                SetGoodStock(RessourceManager.Instance._wood, RessourceManager.Instance._maxWood);
                break; 
            
            case 1:
                StockBatListManager.instance.AddObjectToList(gameObject, 1);
                SetGoodStock(RessourceManager.Instance._water, RessourceManager.Instance._maxWater);
                break;
            case 2:
                StockBatListManager.instance.AddObjectToList(gameObject, 2);
                SetGoodStock(RessourceManager.Instance._stone, RessourceManager.Instance._maxStone);
                break;
        }
    }

    public void SetGoodStock(int _currentStock, int _maxStock)
    {
        int tranche = _maxStock / 5;

        if (_currentStock == 0)
        {
            Stock1.SetActive(true);
            Stock2.SetActive(false);
            Stock3.SetActive(false);
            Stock4.SetActive(false);
            Stock5.SetActive(false);
        }
        else if (tranche * 1 > 0)
        {
            Stock1.SetActive(true);
            Stock2.SetActive(true);
            Stock3.SetActive(false);
            Stock4.SetActive(false);
            Stock5.SetActive(false);
        }
        else if (tranche * 2 > _currentStock) 
        {
            Stock1.SetActive(true);
            Stock2.SetActive(true);
            Stock3.SetActive(true);
            Stock4.SetActive(false);
            Stock5.SetActive(false);
        }
        else if (tranche * 3 > _currentStock)
        {
            Stock1.SetActive(true);
            Stock2.SetActive(true);
            Stock3.SetActive(true);
            Stock4.SetActive(true);
            Stock5.SetActive(false);
        }
        else if (tranche * 4 > _currentStock)
        {
            Stock1.SetActive(true);
            Stock2.SetActive(true);
            Stock3.SetActive(true);
            Stock4.SetActive(true);
            Stock5.SetActive(true);
        }
    }
}