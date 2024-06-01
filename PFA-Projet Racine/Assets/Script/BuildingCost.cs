using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCost : MonoBehaviour
{
    [field : SerializeField] public int WoodCost {  get; private set; }
    [field : SerializeField] public int StoneCost { get; private set; }

    public void BuyBuilding()
    {
        RessourceManager.Instance.EditWoodAmount(-WoodCost);
        RessourceManager.Instance.EditStoneAmount(-StoneCost);
    }
}