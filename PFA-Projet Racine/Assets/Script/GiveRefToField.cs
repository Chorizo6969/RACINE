using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GiveRefToField : MonoBehaviour
{
    [SerializeField] List<GameObject> _targetWorkList;
    public static GiveRefToField instance;

    private void Awake()
    {
        instance = this;
    }

    public void GiveRefPasTuple(GameObject go, GameObject _newPrefabPlant, GameObject _newButtonPrefab, GameObject _newContent)
    {
        if (go.GetComponent<Spawn>() != null)
        {
            Spawn _spawn = go.GetComponent<Spawn>();
            _spawn.HumanPrefab = _newPrefabPlant;
            _spawn.PrefabButton = _newButtonPrefab;
            _spawn.Parent = _newContent;
        }
    }
}