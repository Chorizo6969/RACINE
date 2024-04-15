using System.Collections;
using UnityEngine;

public class Intro : MonoBehaviour
{
    /// <summary>
    /// Lien vers l'animator qui gère l'intro.
    /// </summary>
    [SerializeField]
    private Animator _animator;

    /// <summary>
    /// variable string qui contient le nom de la condition à changé dans l'animator.
    /// </summary>
    [SerializeField]
    private string _conditionName;

    /// <summary>
    /// Variable int pour indiquer le delay avant de lancer l'animation
    /// </summary>
    [SerializeField]
    private int delay = 0;

    private void Start()
    {
        StartCoroutine(Translate());
    }

    /// <summary>
    /// Coroutine qui gère les transitions dans l'animator
    /// </summary>
    /// <returns> retrourne un NewWaitForSeconds de 10s </returns>
    IEnumerator Translate()
    {
        yield return new WaitForSeconds(delay);
        _animator.SetBool(_conditionName, true);
        yield return new WaitForSeconds(10);
    }
}
