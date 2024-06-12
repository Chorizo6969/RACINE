using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.VFX;

/// <summary>
/// Script qui gère le comportement de l'IA
/// </summary>
public class IA : MonoBehaviour
{
    /// <summary>
    /// Lien vers le script des Humains
    /// </summary>
    public Human _scriptableHuman;

    public string Nom;

    public string Adjectif;

    public List<GameObject> work;

    public VisualEffect VFX;

    /// <summary>
    /// lien vers le gameObject
    /// </summary>
    [SerializeField]
    private GameObject _hdv;

    /// <summary>
    /// Variable booléen pour savoir si l'IA doit déposer ses ressources dans l'hdv
    /// </summary>
    private bool _goHdv;

    /// <summary>
    /// Liste pour savoir le nombre de réservoir présent sur la map
    /// </summary>
    public List <GameObject> _reservoir;

    /// <summary>
    /// Cible des humains plantes (forêt, mine, ou rivière)
    /// </summary>
    private GameObject _currentTarget;

    [SerializeField]
    private Animator _animator;


    [field :SerializeField]
    /// <summary>
    /// Lien vers le component NavMesh
    /// </summary>
    public NavMeshAgent _agent { get; set; }

    public bool IsEnExpedition;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        StartCoroutine(Activation());

        if (_scriptableHuman.Work == ("Bucheron"))
        {
            _currentTarget = work[0];
            IncrementHuman.instance.EditBucheron(1);
        }
        else if (_scriptableHuman.Work == ("Mineur"))
        {
            _currentTarget = work[1];
            IncrementHuman.instance.EditStoneMan(1);
        }
        else 
        {
            _currentTarget = work[2];
            IncrementHuman.instance.EditAquaman(1);
        }
    }

    /// <summary>
    /// Fonction qui envoit l'humain plante travailler
    /// </summary>
    public void GiveTarget()
    {
        _agent.speed = 3;
        StopCoroutine(GetComponent<NewRandomPos>().AutorizeMove());
        GetComponent<NewRandomPos>().SetDestinationToGo(_currentTarget.transform.position);
        _animator.SetBool("Job", true);


        //StopCoroutine(GetComponent<RandomBonhommePlant>().AutorizeMove());
        StartCoroutine(Task());
        StartCoroutine(ATTEND());
    }

    /// <summary>
    /// Coroutine qui gère le travaille de l'humain plante puis son dépot de ressource
    /// </summary>
    /// <returns> retourne un new WaitForSeconds de 5s </returns>
    IEnumerator Task()
    {
        IsEnExpedition = true;
        yield return new WaitForSeconds(60);
        GetComponent<HideNSeek>()._startHiding = true;
        IsEnExpedition = false;
        _animator.SetBool("Job", false);
    }

    IEnumerator Activation()
    {
        yield return new WaitForSeconds(0.2f);
        _agent.enabled = true;
    }

    IEnumerator ATTEND()
    {
        yield return new WaitForSeconds(1f);
        //StartCoroutine(GetComponent<RandomBonhommePlant>().AutorizeMove());
    }
}