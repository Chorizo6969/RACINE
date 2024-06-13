using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExpeditionLoot : MonoBehaviour
{
    [SerializeField]
    private int maxlootBois = 10;
    [SerializeField] 
    private int minlootBois = 4;
    [SerializeField]
    private int maxlootPierre = 10;
    [SerializeField]
    private int minlootPierre = 4;
    [SerializeField]
    private int maxlootEau = 10;
    [SerializeField]
    private int minlootEau = 4;
    [SerializeField]
    private int chanceToDie = 10;

    public int expeditionTime = 60;

    [SerializeField]
    private ChangeColor ChangeColorBucheron;
    [SerializeField]
    private ChangeColor ChangeColorAquaman;
    [SerializeField]
    private ChangeColor ChangeColorMineur;

    [SerializeField]
    private TextMeshProUGUI scoreWood;
    [SerializeField]
    private TextMeshProUGUI scoreStone;
    [SerializeField]
    private TextMeshProUGUI scoreWater;
    [SerializeField]
    private Listexpedition listExpeditionOwnerBucheron;
    [SerializeField]
    private Listexpedition listExpeditionOwnerMineur;
    [SerializeField]
    private Listexpedition listExpeditionOwnerAquaman;

    public List<GameObject> listBucheron;

    [SerializeField]
    private List<GameObject> listMineur;
    [SerializeField]
    private List<GameObject> listAquaman;


    public static ExpeditionLoot instance;

    //BUG : On peut lancer plusieurs fois les expéditions
    public void Awake()
    {
        instance = this;
    }

    public void SortHuman()
    {
        foreach (GameObject _human in listExpeditionOwnerBucheron.listHuman)
        {
            if (_human.GetComponent<IA>()._scriptableHuman.Work == ("Bucheron") && !listBucheron.Contains(_human))
            {
                listBucheron.Add(_human);
            }
        }

        foreach (GameObject _human in listExpeditionOwnerMineur.listHuman)
        {
            if (_human.GetComponent<IA>()._scriptableHuman.Work == ("Mineur") && !listMineur.Contains(_human))
            {
                listMineur.Add(_human);
            }
        }

        foreach (GameObject _human in listExpeditionOwnerAquaman.listHuman)
        {
            if (_human.GetComponent<IA>()._scriptableHuman.Work == ("Eau") && !listAquaman.Contains(_human))
            {
                listAquaman.Add(_human);
            }
        }

    }

    public void WorkingWood()
    {
        foreach (GameObject obj in ChangeColorBucheron.HumanInExpedition)
        {
            maxlootBois += 4;
            minlootBois += 4;
        }
            Debug.Log(maxlootBois);
            Debug.Log(minlootBois);
        bool mortBuche = false;
        int scoreWood = 0;
        int lootWood = Random.Range(minlootBois, maxlootBois + 1);
        scoreWood = lootWood;
        maxlootBois = 10;
        minlootBois = 4;
        if (ChangeColorBucheron.HumanInExpedition.Count != 1)
        {
            int humainmort = Random.Range(0, chanceToDie + 1);
            Debug.Log("mort");
            if (humainmort == chanceToDie)
            {
                mortBuche = true;
            }
        }
        StartCoroutine(endExpeditionWood(mortBuche, scoreWood));
    }


    IEnumerator endExpeditionWood(bool mort, int score)
    {
        yield return new WaitForSeconds(expeditionTime);
        if (mort)
        {
            int numberOfDeath = Random.Range(0, ChangeColorBucheron.ButtonOfHumanInExpedition.Count);
            if (numberOfDeath > 0)
            {
                for (int i = 0; i < numberOfDeath; i++)
                {
                    IncrementHuman.instance.Death(1);
                    GameObject FirstButton = ChangeColorBucheron.ButtonOfHumanInExpedition[0];
                    GameObject FirstHuman = ChangeColorBucheron.HumanInExpedition[0];
                    listExpeditionOwnerBucheron.list.Remove(FirstButton);
                    ChangeColorBucheron.ButtonOfHumanInExpedition.Remove(FirstButton);

                    listExpeditionOwnerBucheron.listHuman.Remove(FirstHuman);
                    ChangeColorBucheron.HumanInExpedition.Remove(FirstHuman);
                    listBucheron.Remove(FirstHuman);
                    Destroy(FirstButton);
                    Destroy(FirstHuman);
                }
            }
            RessourceManager.Instance.EditWoodAmount(score);
        }
        else
        {
            RessourceManager.Instance.EditWoodAmount(score);
        }
    }

    public void WorkingStone()
    {
        foreach (GameObject obj in ChangeColorBucheron.HumanInExpedition)
        {
            maxlootPierre += 4;
            minlootPierre += 4;
        }
            Debug.Log(maxlootPierre);
            Debug.Log(minlootPierre);
        bool mortPierre = false;
        int scoreStone = 0;
        int lootStone = Random.Range(minlootPierre, maxlootPierre + 1);
        scoreStone = lootStone;
        maxlootPierre = 10;
        minlootPierre = 4;
        if (ChangeColorMineur.HumanInExpedition.Count != 1)
        {
            int humainmort = Random.Range(0, chanceToDie + 1);
            if (humainmort == chanceToDie)
            {
                mortPierre = true;
            }
        }
        StartCoroutine(endExpeditionStone(mortPierre, scoreStone));
    }

    IEnumerator endExpeditionStone(bool mort, int score)
    {
        yield return new WaitForSeconds(expeditionTime);
        if (mort)
        {
            int numberOfDeath = Random.Range(0, ChangeColorMineur.ButtonOfHumanInExpedition.Count);
            if (numberOfDeath > 0)
            {
                for (int i = 0; i < numberOfDeath; i++)
                {
                    IncrementHuman.instance.Death(1);
                    GameObject FirstButton = ChangeColorMineur.ButtonOfHumanInExpedition[0];
                    GameObject FirstHuman = ChangeColorMineur.HumanInExpedition[0];
                    listExpeditionOwnerMineur.list.Remove(FirstButton);
                    ChangeColorMineur.ButtonOfHumanInExpedition.Remove(FirstButton);

                    listExpeditionOwnerMineur.list.Remove(FirstHuman);
                    ChangeColorMineur.HumanInExpedition.Remove(FirstHuman);
                    listMineur.Remove(FirstHuman);
                    Destroy(FirstButton);
                    Destroy(FirstHuman);
                }
            }
        }
        else
        {
            RessourceManager.Instance.EditStoneAmount(score);
        }
    }


    public void WorkingWater()
    {
        foreach (GameObject obj in ChangeColorBucheron.HumanInExpedition)
        {
            maxlootEau += 4;
            minlootEau += 4;
        }
            Debug.Log(maxlootEau);
            Debug.Log(minlootEau);
        bool mortAquaman = false;
        int WaterScore = 0;
        int lootWater = Random.Range(minlootEau, maxlootEau + 1);
        WaterScore = lootWater;
        maxlootPierre = 10;
        minlootPierre = 4;
        if (ChangeColorAquaman.HumanInExpedition.Count != 1)
        {
            int humainmort = Random.Range(0, chanceToDie + 1);
            if (humainmort == chanceToDie)
            {
                mortAquaman = true;
            }
        }
        StartCoroutine(endExpeditionWater(mortAquaman, WaterScore));
    }

    IEnumerator endExpeditionWater(bool mort, int score)
    {
        yield return new WaitForSeconds(expeditionTime);
        if (mort)
        {
            int numberOfDeath = Random.Range(0, ChangeColorAquaman.ButtonOfHumanInExpedition.Count);
            if (numberOfDeath > 0)
            {
                for (int i = 0; i < numberOfDeath; i++)
                {
                    IncrementHuman.instance.Death(1);
                    GameObject FirstButton = ChangeColorAquaman.ButtonOfHumanInExpedition[0];
                    GameObject FirstHuman = ChangeColorAquaman.HumanInExpedition[0];
                    listExpeditionOwnerAquaman.list.Remove(FirstButton);
                    ChangeColorAquaman.ButtonOfHumanInExpedition.Remove(FirstButton);

                    listExpeditionOwnerAquaman.list.Remove(FirstHuman);
                    ChangeColorAquaman.HumanInExpedition.Remove(FirstHuman);
                    listAquaman.Remove(FirstHuman);
                    Destroy(FirstButton);
                    Destroy(FirstHuman);
                }
            }
            /*else
            {
                RessourceManager.Instance.EditWaterAmount(score);
            }*/
        }
        else
        {
            RessourceManager.Instance.EditWaterAmount(score);
        }
    }
}