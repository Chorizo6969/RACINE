using TMPro;
using UnityEngine;

public class AchatSeed : MonoBehaviour
{
    public RessourceManager RessourceManager;
    public TextMeshProUGUI textWood;
    public TextMeshProUGUI textWood2;
    public TextMeshProUGUI textStone;
    public TextMeshProUGUI textO;
    public TextMeshProUGUI textO2;
    private int index = 1;

    public void Start()
    {
        string wood = "20";
        string water = "20";
        textWood.text = wood.ToString();
        textO.text = water.ToString();
    }
    public void UpgradeRoot()
    {
        if (index == 1)
        {
            string wood = "35";
            string stone = "15";
            string water = "50";
            textWood2.text = wood.ToString();
            textStone.text = stone.ToString();
            textO2.text = water.ToString();
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
