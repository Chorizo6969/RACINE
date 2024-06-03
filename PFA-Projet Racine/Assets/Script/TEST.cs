using System.Collections;
using UnityEngine;

public class TEST : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Blorg());
    }

    IEnumerator Blorg()
    {
        yield return new WaitForSeconds(3600);
    }
}