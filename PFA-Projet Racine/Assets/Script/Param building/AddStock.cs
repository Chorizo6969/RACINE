using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.RenderGraphModule;

public class AddStock : MonoBehaviour
{
    [SerializeField] int id;
    [SerializeField] int stock;

    private void Start()
    {
        switch (id)
        {
            case 0:
                RessourceManager.Instance.AddWoodStock(stock);
                break;
            case 1:
                RessourceManager.Instance.AddWaterStock(stock);
                break;
            case 2:
                RessourceManager.Instance.AddStoneStock(stock);
                break;
        }
    }
}