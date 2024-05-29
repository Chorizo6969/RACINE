using System.Collections;
using UnityEngine;

public class TriggerAnim : MonoBehaviour
{
    [SerializeField]
    private Animation _plongeon;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            _plongeon.Play("animation plongeon");
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(50);
        _plongeon.Play("Sortie eau");
    }
}
