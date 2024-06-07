using System.Collections.Generic;
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
    [SerializeField]
    private GameObject Racine1;
    [SerializeField]
    private GameObject Racine2;
    [SerializeField]
    private GameObject Racine3;

    [SerializeField]
    private GameObject HerbeMineur;
    [SerializeField]
    private GameObject Mineur;
    [SerializeField]
    private TextMeshProUGUI textMineur;

    public List<GameObject> ListeButtonLvl2;
    public List<GameObject> ListePanelLockLvl2;
    public List<GameObject> ListeButtonLvl3;
    public List<GameObject> ListePanelLockLvl3;

    private int index = 1;

    public void Start()
    {
        Mineur.SetActive(false);
        HerbeMineur.SetActive(false);
        Racine1.SetActive(true);
        Racine2.SetActive(false);
        Racine3.SetActive(false);
        _textRacine.text = "1".ToString();
        prix1.SetActive(true);
        prix2.SetActive(false);
        string wood = "30";
        string water = "40";
        textWood.text = wood.ToString();
        textO.text = water.ToString();
        foreach(GameObject obj in ListeButtonLvl2)
        {
            Button button = obj.GetComponent<Button>();
            button.interactable = false;
        }
        foreach (GameObject obj in ListeButtonLvl3)
        {
            Button button = obj.GetComponent<Button>();
            button.interactable = false;
        }
    }
    public void UpgradeRoot()
    {
        if (index == 1)
        {
            string wood = "40";
            string stone = "20";
            string water = "60";
            textWood2.text = wood.ToString();
            textStone.text = stone.ToString();
            textO2.text = water.ToString();
            if (RessourceManager.CheckIfCanBuild(30,0,40))
            {
                _textRacine.text = "2".ToString();
                RessourceManager.EditWoodAmount(-30);
                RessourceManager.EditWaterAmount(-40);
                index = 2;
                prix1.SetActive(false);
                prix2.SetActive(true);
                Racine1.SetActive(false);
                Racine2.SetActive(true);
                foreach (GameObject obj in ListeButtonLvl2)
                {
                    Button button = obj.GetComponent<Button>();
                    button.interactable = true;
                }
                foreach (GameObject obj in ListePanelLockLvl2)
                {
                    obj.SetActive(false);
                }
                Mineur.SetActive(true);
                HerbeMineur.SetActive(true);
                textMineur.text = "1 pierre 3 bois".ToString();
                textMineur.color = Color.black;
            }
        }
        else if (index == 2)
        {
            if (RessourceManager.CheckIfCanBuild(40, 20, 60))
            {
                prix3.GetComponentInParent<Button>().enabled = false;
                _textRacine.text = "3".ToString();
                RessourceManager.EditWoodAmount(-40);
                RessourceManager.EditStoneAmount(-20);
                RessourceManager.EditWaterAmount(-60);
                prix1.SetActive(false);
                prix2.SetActive(false);
                prix3.SetActive(true);
                Racine2.SetActive(false);
                Racine3.SetActive(true);
                foreach (GameObject obj in ListeButtonLvl3)
                {
                    Button button = obj.GetComponent<Button>();
                    button.interactable = true;
                }
                foreach (GameObject obj in ListePanelLockLvl3)
                {
                    obj.SetActive(false);
                }
            }
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