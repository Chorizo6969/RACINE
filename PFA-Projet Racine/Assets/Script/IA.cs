using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IA : MonoBehaviour
{
    [SerializeField]
    private Human _scriptableHuman;
    [SerializeField]
    private GameObject _jobTarget1;
    [SerializeField]
    private GameObject _jobTarget2;
    [SerializeField]
    private GameObject _jobTarget3;
    [SerializeField]
    private GameObject _hdv;

    private bool _goHdv;
    public List <GameObject> _reservoir;
    private GameObject _currentTarget;

    private NavMeshAgent _agent;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        if (_scriptableHuman.Work == ("Bucheron"))
        {
            _currentTarget = _jobTarget1;
        }
        else if (_scriptableHuman.Work == ("Mineur"))
        {
            _currentTarget = _jobTarget2;
        }
        else 
        { 
            _currentTarget = _jobTarget3;
        }

    }

    private void Update()
    {

        if (_reservoir == null)
        {
            _goHdv = true;
        }
    }

    public void GiveTarget()
    {
        _agent.SetDestination(_currentTarget.transform.position); //Ne met pas à jours le chemin de l'IA
        StartCoroutine(Task());
    }

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
