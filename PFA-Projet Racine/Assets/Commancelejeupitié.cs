using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commancelejeupitié : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _introObjects;

    [SerializeField]
    private bool _startFromTuto;

    void Start()
    {
        if(!_startFromTuto) { return; }
        foreach(GameObject obj in _introObjects)
        {
            obj.SetActive(true);
        }
    }
}
