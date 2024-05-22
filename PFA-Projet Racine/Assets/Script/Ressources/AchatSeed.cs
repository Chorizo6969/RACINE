using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchatSeed : MonoBehaviour
{
    [SerializeField]
    private RessourceManager RessourceManager;
    [SerializeField]
    private TextMeshProUGUI _textRacine;
    [SerializeField]
    private TextMeshProUGUI textWood;
    [SerializeField]
    private TextMeshProUGUI textWood2;
    [SerializeField]
    private TextMeshProUGUI textStone;
    [SerializeField]
    private TextMeshProUGUI textO;
    [SerializeField]
    private TextMeshProUGUI textO2;
    [SerializeField]
    private GameObject prix1;
    [SerializeField]
    private GameObject prix2;
    [SerializeField]
    private GameObject prix3;
    [SerializeField]
    private GivePlant builder;
    [SerializeField]
    private GivePlant bucheron;
    [SerializeField]
    private GivePlant mineur;
    [SerializeField]
    private GivePlant aquaman;

    private int index = 1;

    public void Start()
    {
        _textRacine.text = "1".ToString();
        prix1.SetActive(true);
        prix2.SetActive(false);
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
            if (RessourceManager.CheckIfCanBuild(20,0,20))
            {
                _textRacine.text = "2".ToString();
                RessourceManager.EditWoodAmount(-20);
                RessourceManager.EditWaterAmount(-30);
                index = 2;
                prix1.SetActive(false);
                prix2.SetActive(true);
            }
        }
        else if (index == 2)
        {
            if (RessourceManager.CheckIfCanBuild(35, 15, 50))
            {
                prix3.GetComponentInParent<Button>().enabled = false;
                _textRacine.text = "3".ToString();
                RessourceManager.EditWoodAmount(-35);
                RessourceManager.EditStoneAmount(-15);
                RessourceManager.EditWaterAmount(-50);
                prix1.SetActive(false);
                prix2.SetActive(false);
                prix3.SetActive(true);
            }
        }
    }

    public void SetBuilder()
    {
        if (RessourceManager.CheckIfCanBuild(2,2,0))
        {
            RessourceManager.EditWoodAmount(-2);
            RessourceManager.EditStoneAmount(-2);
            builder._nombreGraines++;
        }
    }

    public void SetWoodcutter()
    {
        if (RessourceManager.CheckIfCanBuild(4, 0, 0))
        {
            RessourceManager.EditWoodAmount(-4);
            bucheron._nombreGraines++;
        }
    }

    public void SetMineur()
    {
        if (RessourceManager.CheckIfCanBuild(1, 3, 0))
        {
            RessourceManager.EditWoodAmount(-1);
            RessourceManager.EditStoneAmount(-3);
            mineur._nombreGraines++;
        }
    }

    public void SetWater()
    {
        if (RessourceManager.CheckIfCanBuild(1, 0, 3))
        {
            RessourceManager.EditWoodAmount(-1);
            RessourceManager.EditWaterAmount(-3);
            aquaman._nombreGraines++;
        }

    }
}
