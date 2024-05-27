using System.Collections;
using UnityEngine;

public class Desactivateur : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.9f);
        gameObject.SetActive(false);
    }
}
