using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listexpedition : MonoBehaviour
{
    public List<GameObject> list;

    public void AddObject(GameObject obj)
    {
        list.Add(obj);
    }
}
