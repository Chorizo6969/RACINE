using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject PrefabBûcheron;
    public GameObject PrefabButton;
    public GameObject Parent;
    public GameObject ListParent;
    public List<GameObject> worktarget;

    public NamesGenerator NamesGenerator;

    public void Spawner()
    {
        GameObject new_button = Instantiate(PrefabButton);
        new_button.transform.parent = Parent.transform;
        ListParent.GetComponent<Listexpedition>().AddObject(new_button);
        GameObject new_human = Instantiate(PrefabBûcheron);
        new_human.GetComponent<IA>().work = worktarget;
        NamesGenerator.RandomName();
        new_human.GetComponent<IA>().Nom = NamesGenerator.Nom;
        new_human.GetComponent<IA>().Adjectif = NamesGenerator.Adjectif;
        new_button.GetComponent<Expédition>().Ia = new_human;
        new_button.GetComponent<ChangeColor>().expédition = new_button.GetComponent<Expédition>();
    }
}
