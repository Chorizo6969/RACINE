using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private string _conditionName;
    [SerializeField]
    private int delay = 0;

    private void Start()
    {
        StartCoroutine(Translate());
    }

    IEnumerator Translate()
    {
        yield return new WaitForSeconds(delay);
        _animator.SetBool(_conditionName, true);
        yield return new WaitForSeconds(10);
    }
}
