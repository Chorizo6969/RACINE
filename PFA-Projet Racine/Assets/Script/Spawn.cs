using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Spawn : MonoBehaviour
{
    public GameObject HumanPrefab;
    public GameObject PrefabButtonBucheron;
    public GameObject PrefabButtonAquaman;
    public GameObject PrefabButtonMineur;
    public GameObject Parent;

    public VisualEffect _visualEffectEau1;
    public VisualEffect _visualEffectEau2;

    public List<GameObject> worktarget;
    public NamesGenerator NamesGenerator;

    private void Start()
    {
        NamesGenerator = NamesGenerator.Instance;
        worktarget = TargetList.instance.TargetListObjects;
    }

    public void Spawner()
    {
        GameObject new_button = ChoseButton(HumanPrefab.GetComponent<IA>()._scriptableHuman.Work);
        new_button.transform.parent = Parent.transform;
        GameObject new_human = Instantiate(HumanPrefab);
        IncrementHuman.instance.Stonks();
        Parent.GetComponent<Listexpedition>().AddObjectAI(new_human);
        new_human.GetComponent<IA>().work = worktarget;
        NamesGenerator.RandomName();
        new_human.GetComponent<IA>().Nom = NamesGenerator.Nom;
        new_human.GetComponent<IA>().Adjectif = NamesGenerator.Adjectif;
        if (new_human.GetComponent <IA>()._scriptableHuman.Work == "Eau")
        {
            Debug.Log("Attribution");
            new_human.GetComponent<TriggerAnim>()._visualEffect = _visualEffectEau1;
            new_human.GetComponent<TriggerAnim>()._visualEffect2 = _visualEffectEau2;
        }
        new_button.GetComponent<Expédition>().Ia = new_human;
        new_button.GetComponent<ChangeColor>().expédition = new_button.GetComponent<Expédition>();

        new_human.transform.position = GetComponent<Field>()._currentPlant.transform.position;
        ExpeditionLoot.instance.SortHuman();
    }

    public GameObject ChoseButton(string metier)
    {
        if (metier == "Bucheron")
        {
            GameObject new_button = Instantiate(PrefabButtonBucheron);
            new_button.transform.parent = Parent.transform;
            Parent.GetComponent<Listexpedition>().AddObject(new_button);
            return new_button;
        }
        else if (metier == "Eau")
        {
            GameObject new_button = Instantiate(PrefabButtonAquaman);
            new_button.transform.parent = Parent.transform;
            Parent.GetComponent<Listexpedition>().AddObject(new_button);
            return new_button;
        }
        else
        {
            GameObject new_button = Instantiate(PrefabButtonMineur);
            new_button.transform.parent = Parent.transform;
            Parent.GetComponent<Listexpedition>().AddObject(new_button);
            return new_button;
        }
    }

    IEnumerator Unity()
    {
        yield return new WaitForSeconds(0.25f);
    }
}