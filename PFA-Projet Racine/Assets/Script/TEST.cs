using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TEST : MonoBehaviour
{
    private void Start()
    {
        //StartCoroutine(Test());
    }

    IEnumerator Test()
    {
        yield return new WaitForSeconds(0.1f);
        Debug.Log(transform.position);
        StartCoroutine(Test());
    }

    private void Update()
    {
        Debug.Log(transform.position);
    }
}