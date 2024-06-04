using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExpeditionLoot : MonoBehaviour
{
    [SerializeField]
    private int maxloot = 10;
    [SerializeField] 
    private int minloot = 4;
    [SerializeField]
    private int chanceToDie = 10;

    public int expeditionTime = 60;
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

    //BUG : Index de merde
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
        bool mortBuche = false;
        int scoreWood = 0;
        int lootWood = Random.Range(minloot, maxloot + 1);
        scoreWood = lootWood;
        int humainmort = Random.Range(0, chanceToDie + 1);
        if (humainmort == chanceToDie)
        {
            mortBuche = true;
        }
        StartCoroutine(endExpeditionWood(mortBuche, scoreWood));
    }


    IEnumerator endExpeditionWood(bool mort, int score)
    {
        yield return new WaitForSeconds(expeditionTime);
        if (mort == true)
        {

            int indexmort = Random.Range(0, listBucheron.Count);
            GameObject _humanToDestroy = listBucheron[indexmort]; // tout les humains, pas que l'expédition.
            IncrementHuman.instance.Death(indexmort);
            listBucheron.Remove(_humanToDestroy);
            Destroy(_humanToDestroy);
            //Détruire l'image humain dans panel expé
            RessourceManager.Instance.EditWoodAmount(score);
        }
        else
        {
            RessourceManager.Instance.EditWoodAmount(score);
        }
    }

    public void WorkingStone()
    {
        bool mortPierre = false;
        int scoreStone = 0;
        int lootStone = Random.Range(minloot, maxloot + 1);
        scoreStone = lootStone;
        int humainmort = Random.Range(0, chanceToDie + 1);
        if (humainmort == chanceToDie)
        {
            mortPierre = true;
        }
        StartCoroutine(endExpeditionStone(mortPierre, scoreStone));
    }

    IEnumerator endExpeditionStone(bool mort, int score)
    {
        yield return new WaitForSeconds(expeditionTime);
        if (mort == true)
        {
            int indexmort = Random.Range(0, listMineur.Count);
            GameObject _humanToDestroy = listMineur[indexmort];
            IncrementHuman.instance.Death(indexmort);
            listMineur.Remove(_humanToDestroy);
            Destroy(_humanToDestroy);
            RessourceManager.Instance.EditStoneAmount(score);
        }
        else
        {
            RessourceManager.Instance.EditStoneAmount(score);
        }

    }

    public void WorkingWater()
    {
        bool mortAquaman = false;
        int WaterScore = 0;
        int lootWater = Random.Range(minloot, maxloot + 1);
        WaterScore = lootWater;
        int humainmort = Random.Range(0, chanceToDie + 1);
        if (humainmort == chanceToDie)
        {
            mortAquaman = true;
        }
        StartCoroutine(endExpeditionWater(mortAquaman, WaterScore));
    }

    IEnumerator endExpeditionWater(bool mort, int score)
    {
        yield return new WaitForSeconds(expeditionTime);
        if (mort == true)
        {
            int indexmort = Random.Range(0, listAquaman.Count);
            GameObject _humanToDestroy = listAquaman[indexmort];
            IncrementHuman.instance.Death(indexmort);
            listAquaman.Remove(_humanToDestroy);
            Destroy(_humanToDestroy);
            RessourceManager.Instance.EditWaterAmount(score);
        }
        else
        {
            RessourceManager.Instance.EditWaterAmount(score);
        }
    }
}
