using System.Collections;
using UnityEngine;

public class TriggerAnim : MonoBehaviour
{
    private Animator _plongeon;

    private void Start()
    {
        _plongeon = GetComponentInChildren<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 15)
        {
            _plongeon.SetBool("Plonge", true);
            _plongeon.SetBool("Job", false);
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(40);
        _plongeon.SetBool("Plonge", false);
        _plongeon.SetBool("Job", true);
    }
}
