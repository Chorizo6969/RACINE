using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

public class TriggerAnim : MonoBehaviour
{
    private Animator _plongeon;

    public VisualEffect _visualEffect;
    public VisualEffect _visualEffect2;

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
            StartCoroutine(VFXPlonge());
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(40);
        _plongeon.SetBool("Plonge", false);
        _plongeon.SetBool("Job", true);
    }

    IEnumerator VFXPlonge()
    {
        yield return new WaitForSeconds(1);
        _visualEffect.Play();
        _visualEffect2.Play();
    }
}
