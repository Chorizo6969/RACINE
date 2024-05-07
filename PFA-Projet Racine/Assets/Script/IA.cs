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
    [SerializeField]
    private Human _scriptableHuman;

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

    /// <summary>
    /// Lien vers le component NavMesh
    /// </summary>
    private NavMeshAgent _agent;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        if (_scriptableHuman.Work == ("Bucheron"))
        {
            _currentTarget = work[0];
        }
        else if (_scriptableHuman.Work == ("Mineur"))
        {
            _currentTarget = work[1];
        }
        else 
        {
            _currentTarget = work[2];
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
        _agent.SetDestination(_currentTarget.transform.position); //Ne met pas à jours le chemin de l'IA
        //StartCoroutine(Task());
    }

    /// <summary>
    /// Coroutine qui gère le travaille de l'humain plante puis son dépot de ressource
    /// </summary>
    /// <returns> retourne un new WaitForSeconds de 5s </returns>
    IEnumerator Task()
    {
        yield return new WaitForSeconds(5);
        if (_goHdv )
        {
            _agent.SetDestination(new Vector3(3, 0.8277f, 3));
            //lien pour stonks les ressources
        }
        else
        {
            _agent.SetDestination(new Vector3(1, 0, 0));
        }
    }
}
