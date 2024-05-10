using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject HumanPrefab;
    public GameObject PrefabButton;
    public GameObject Parent;

    public List<GameObject> worktarget;
    public NamesGenerator NamesGenerator;

    private void Awake()
    {
        NamesGenerator = NamesGenerator.Instance;
        worktarget = TargetList.instance.TargetListObjects;
    }

    public void Spawner()
    {
        GameObject new_button = Instantiate(PrefabButton);
        new_button.transform.parent = Parent.transform;
        Parent.GetComponent<Listexpedition>().AddObject(new_button);
        GameObject new_human = Instantiate(HumanPrefab);
        new_human.GetComponent<IA>().work = worktarget;
        NamesGenerator.RandomName();
        new_human.GetComponent<IA>().Nom = NamesGenerator.Nom;
        new_human.GetComponent<IA>().Adjectif = NamesGenerator.Adjectif;
        new_button.GetComponent<Expédition>().Ia = new_human;
        new_button.GetComponent<ChangeColor>().expédition = new_button.GetComponent<Expédition>();
        new_human.transform.position = GetComponent<Field>()._currentPlant.transform.position;
    }
}