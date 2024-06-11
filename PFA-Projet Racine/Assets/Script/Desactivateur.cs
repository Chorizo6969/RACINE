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
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}
