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

    public void GiveRefPasTuple(GameObject go, GameObject _newPrefabPlant, GameObject _newButtonPrefabBuche, GameObject _newButtonPrefabAquaman, GameObject _newButtonPrefabMineur, GameObject _newContent)
    {
        if (go.GetComponent<Spawn>() != null)
        {
            Spawn _spawn = go.GetComponent<Spawn>();
            _spawn.HumanPrefab = _newPrefabPlant;
            _spawn.PrefabButtonBucheron = _newButtonPrefabBuche;
            _spawn.PrefabButtonAquaman = _newButtonPrefabAquaman;
            _spawn.PrefabButtonMineur = _newButtonPrefabMineur;
            _spawn.Parent = _newContent;
        }
    }
}