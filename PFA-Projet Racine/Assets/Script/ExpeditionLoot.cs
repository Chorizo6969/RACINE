using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExpeditionLoot : MonoBehaviour
{
    [SerializeField]
    private int maxloot = 10;
    [SerializeField]
    private int chanceToDie = 10;
    [SerializeField]
    private int expeditionTime = 60;
    [SerializeField]
    private TextMeshProUGUI scoreWood;
    [SerializeField]
    private GameObject listExpeditionOwner;
    [SerializeField]
    private List<GameObject> listBucheron;

    private int woodscore;

    private bool mort = false;


    public static ExpeditionLoot instance;

    //BUG : On peut lancer plusieurs fois les expéditions
    public void Awake()
    {
        instance = this;
    }

    public void SortHuman()
    {
        foreach (GameObject _human in listExpeditionOwner.GetComponent<Listexpedition>().listHuman)
        {
            if (_human.GetComponent<IA>()._scriptableHuman.Work == ("Bucheron") && !listBucheron.Contains(_human))
            {
                listBucheron.Add(_human);
            }
        }
    }

    public void WorkingWood()
    {
        mort = false;
        woodscore = 0;
        int lootWood = Random.Range(0, maxloot + 1);
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
            int indexmort = Random.Range(0, listBucheron.Count);
            GameObject _humanToDestroy = listBucheron[indexmort];
            listBucheron.Remove(_humanToDestroy);
            Destroy(_humanToDestroy);
        }
        scoreWood.text += woodscore.ToString();
    }
}
