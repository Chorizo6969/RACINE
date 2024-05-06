using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePointList : MonoBehaviour
{
    [field : SerializeField] public List<GameObject> HidePointsList { get; private set; }

    public void AddObjectInList(GameObject obj) 
    {
        HidePointsList.Add(obj);
    }
}