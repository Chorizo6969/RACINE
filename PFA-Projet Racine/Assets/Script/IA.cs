using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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

    private void Update()
    {

        if (_reservoir == null)
        {
            _goHdv = true;
        }
    }

    /// <summary>
    /// Fonction qui envoit l'humain plante travailler
    /// </summary>
    public void GiveTarget()
    {
        _agent.speed = 3;
        _animator.SetTrigger("Job");
        //_agent.SetDestination(_currentTarget.transform.position); //Ne met pas à jours le chemin de l'IA
        StopCoroutine(GetComponent<NewRandomPos>().AutorizeMove());
        GetComponent<NewRandomPos>().SetDestinationToGo(_currentTarget.transform.position);


        //StopCoroutine(GetComponent<RandomBonhommePlant>().AutorizeMove());
        StartCoroutine(Task());
        _animator.SetTrigger("Job");
        if (_currentTarget = work[2])
        {
            StartCoroutine(AnimationJump());
        }
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
        if (_currentTarget = work[2])
        {
            _animator.SetTrigger("Fin");
        }
        _animator.SetTrigger("Walk");
        GetComponent<HideNSeek>()._startHiding = true;
        IsEnExpedition = false;
        if (_goHdv )
        {
            /*_agent.SetDestination(new Vector3(3, 0.8277f, 3));*/
        }
        else
        {
            /*_agent.SetDestination(new Vector3(1, 0, 0));*/
        }
    }

    IEnumerator Activation()
    {
        yield return new WaitForSeconds(0.2f);
        _agent.enabled = true;
    }

    IEnumerator ATTEND()
    {
        yield return new WaitForSeconds(0.001f);
        //StartCoroutine(GetComponent<RandomBonhommePlant>().AutorizeMove());
    }

    IEnumerator AnimationJump()
    {
        //StopCoroutine(GetComponent<RandomBonhommePlant>().AutorizeMove());
        if (Vector3.Distance(gameObject.transform.position, _currentTarget.transform.position) <= 0.5f)
        {
            _animator.SetTrigger("Task");
        }
        else
        {
            yield return new WaitForSeconds(1);
            StartCoroutine(AnimationJump());
        }
    }
}