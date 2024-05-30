using System.Collections;
using UnityEngine;

public class TriggerAnim : MonoBehaviour
{
    private Animator _plongeon;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("qergeqr");
        if (other.gameObject.layer == 8)
        {
            _plongeon = other.GetComponentInChildren<Animator>();
            _plongeon.SetBool("Plonge", true);
            _plongeon.SetBool("Job", false);
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(50);
        _plongeon.SetBool("Plonge", false);
        _plongeon.SetBool("Job", true);
    }
}
