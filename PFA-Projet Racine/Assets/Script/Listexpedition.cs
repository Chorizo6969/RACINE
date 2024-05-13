using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listexpedition : MonoBehaviour
{
    public List<GameObject> list;
    public List<GameObject> listHuman;
    public static Listexpedition instance;


    public void Awake()
    {
        instance = this;
    }

    public void AddObject(GameObject obj)
    {
        list.Add(obj);
    }

    public void AddObjectAI(GameObject obj)
    {
        listHuman.Add(obj);
    }
}
