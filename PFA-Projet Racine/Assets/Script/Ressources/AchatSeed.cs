using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchatSeed : MonoBehaviour
{
    public RessourceManager RessourceManager;
    private int index = 1;

    public void UpgradeRoot()
    {
        if (index == 1)
        {
            RessourceManager.EditWoodAmount(-20);
            RessourceManager.EditWaterAmount(-30);
            index = 2;
        }
        else if (index == 2)
        {
            RessourceManager.EditWoodAmount(-35);
            RessourceManager.EditStoneAmount(-15);
            RessourceManager.EditWaterAmount(-50);
        }
    }

    public void SetBuilder()
    {
        RessourceManager.EditWoodAmount(-2);
        RessourceManager.EditStoneAmount(-2);
        //Donner 1 graine
    }

    public void SetWoodcutter()
    {
        RessourceManager.EditWoodAmount(-4);
        //Donner 1 graine
    }

    public void SetMineur()
    {
        RessourceManager.EditWoodAmount(-1);
        RessourceManager.EditStoneAmount(-3);
        //Donner 1 graine
    }

    public void SetWater()
    {
        RessourceManager.EditWoodAmount(-1);
        RessourceManager.EditWaterAmount(-3);
        //Donner 1 graine
    }
}
