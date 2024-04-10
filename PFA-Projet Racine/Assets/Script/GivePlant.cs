using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GivePlant : MonoBehaviour
{
    [SerializeField] private GameObject _seed;
    [SerializeField] private GameObject _camera;

    public void OnClick()
    {
        _camera.GetComponent<ClickFieldManager>().HumanSeed = _seed;
    }
}
