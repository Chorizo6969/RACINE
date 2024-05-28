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
    [SerializeField]
    private int expeditionTime = 60;
    [SerializeField]
    private TextMeshProUGUI scoreWood;
    [SerializeField]
    private TextMeshProUGUI scoreStone;
    [SerializeField]
    private TextMeshProUGUI scoreWater;
    [SerializeField]
    private GameObject listExpeditionOwnerBucheron;
    [SerializeField]
    private GameObject listExpeditionOwnerMineur;
    [SerializeField]
    private GameObject listExpeditionOwnerAquaman;
    [SerializeField]
    private List<GameObject> listBucheron;
    [SerializeField]
    private List<GameObject> listMineur;
    [SerializeField]
    private List<GameObject> listAquaman;

    private int woodscore;

    private bool mort = false;
    private int index = 1;


    public static ExpeditionLoot instance;

    //BUG : On peut lancer plusieurs fois les expéditions
    public void Awake()
    {
        instance = this;
        mort = false;
    }

    public void SortHuman()
    {
        foreach (GameObject _human in listExpeditionOwnerBucheron.GetComponent<Listexpedition>().listHuman)
        {
            if (_human.GetComponent<IA>()._scriptableHuman.Work == ("Bucheron") && !listBucheron.Contains(_human))
            {
                listBucheron.Add(_human);
                index = 1;
            }
        }

        foreach (GameObject _human in listExpeditionOwnerMineur.GetComponent<Listexpedition>().listHuman)
        {
            if (_human.GetComponent<IA>()._scriptableHuman.Work == ("Mineur") && !listMineur.Contains(_human))
            {
                listMineur.Add(_human);
                index = 2;
            }
        }

        foreach (GameObject _human in listExpeditionOwnerAquaman.GetComponent<Listexpedition>().listHuman)
        {
            if (_human.GetComponent<IA>()._scriptableHuman.Work == ("Eau") && !listAquaman.Contains(_human))
            {
                listAquaman.Add(_human);
                index = 3;
            }
        }

    }

    public void WorkingWood()
    {
        Debug.Log("expédition lancé");
        mort = false;
        woodscore = 0;
        int lootWood = Random.Range(minloot, maxloot + 1);
        woodscore = lootWood;
        int humainmort = Random.Range(0, chanceToDie + 1);
        if (humainmort == chanceToDie)
        {
            mort = true;
        }
        StartCoroutine(endExpedition());
    }

    IEnumerator endExpedition()
    {
        yield return new WaitForSeconds(expeditionTime);
        if (mort == true)
        {
            if (index == 1)
            {
                int indexmort = Random.Range(0, listBucheron.Count);
                GameObject _humanToDestroy = listBucheron[indexmort];
                IncrementHuman.instance.Death(indexmort);
                listBucheron.Remove(_humanToDestroy);
                Destroy(_humanToDestroy);
                RessourceManager.Instance.EditWoodAmount(woodscore);

            }
            else if (index == 2)
            {
                int indexmort = Random.Range(0, listMineur.Count);
                GameObject _humanToDestroy = listMineur[indexmort];
                IncrementHuman.instance.Death(indexmort);
                listMineur.Remove(_humanToDestroy);
                Destroy(_humanToDestroy);
                RessourceManager.Instance.EditStoneAmount(woodscore);
            }
            else
            {
                int indexmort = Random.Range(0, listAquaman.Count);
                GameObject _humanToDestroy = listAquaman[indexmort];
                IncrementHuman.instance.Death(indexmort);
                listAquaman.Remove(_humanToDestroy);
                Destroy(_humanToDestroy);
                RessourceManager.Instance.EditWaterAmount(woodscore);
            }
        }
        else
        {
            if (index == 1)
            {
                RessourceManager.Instance.EditWoodAmount(woodscore);
            }
            else if (index == 2)
            {
                RessourceManager.Instance.EditStoneAmount(woodscore);
            }
            else
            {
                RessourceManager.Instance.EditWaterAmount(woodscore);
            }
        }
    }
}
