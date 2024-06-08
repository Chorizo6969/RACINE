using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

/// <summary>
/// Script qui fait pousser la plante
/// </summary>
public class Grow : MonoBehaviour
{
    /// <summary>
    /// vitesse de croissance de la plante
    /// </summary>
    [field : SerializeField] public float _growSpeed {  get; private set; }
            
    /// <summary>
    /// hauteur max à laquelle
    /// </summary>
    [SerializeField] private float _maxHighGrow;

    public GameObject VFX;
    private void Start()
    {
        GetComponent<Animator>().SetTrigger("IsPlanted");
        StartCoroutine(ATTEND());
        VFX.GetComponent<VisualEffect>().Stop();
    }

    IEnumerator ATTEND()
    {
        yield return new WaitForSeconds(3);
        GetComponent<Animator>().SetTrigger("IsReady");
        VFX.GetComponent<VisualEffect>().Play();
    }
}