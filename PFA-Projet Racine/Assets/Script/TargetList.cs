using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetList : MonoBehaviour
{
    public static TargetList instance;
    public List<GameObject> TargetListObjects;

    private void Awake()
    {
        instance = this;
    }
}