using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class NewRandomPos : MonoBehaviour
{
    [SerializeField] private GameObject _listOwner;
    public Vector3 _positionToGo;
    private NavMeshAgent _navMeshAgent;

    [SerializeField] Animator _animator;

    private HideNSeek _hideNSeed;
    private IA _IA;

    public int timeToWait;

    public float tempo;

    private void Awake()
    {
        _listOwner = wayPointPosManager.Instance.gameObject;
    }

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
        _hideNSeed = GetComponent<HideNSeek>();
        _IA = GetComponent<IA>();
        StartCoroutine(ATTEND());
    }

    private void Update()
    {
        tempo = Vector3.Distance(gameObject.transform.position, _positionToGo);
        if (Vector3.Distance(gameObject.transform.position, _positionToGo) < 0.25f)
        {
            _navMeshAgent.speed = 0;
            _animator.SetTrigger("Breath");
        }
    }

    Vector3 FindRandomPointToGo()
    {
        _positionToGo = _listOwner.GetComponent<wayPointPosManager>().WayPoints[Random.Range(0, _listOwner.GetComponent<wayPointPosManager>().WayPoints.Count)].transform.position;
        return _positionToGo;
    }

    public void SetDestinationToGo(Vector3 destination)
    {
        _positionToGo = destination;
        _navMeshAgent.SetDestination(_positionToGo);
    }

    IEnumerator MoveManager()
    {
        StartCoroutine(AutorizeMove());
        if (!_hideNSeed.IsHiding && !_IA.IsEnExpedition)
        {
            SetDestinationToGo(FindRandomPointToGo());
        }
        yield return new WaitForSeconds(timeToWait*2);
        StartCoroutine(MoveManager());
    }

    public IEnumerator AutorizeMove()
    {
        if (!_hideNSeed.IsHiding && !_IA.IsEnExpedition)
        {
            timeToWait = Random.Range(2, 7);
            _navMeshAgent.speed = 0;
            _animator.SetTrigger("Breath");
            yield return new WaitForSeconds(timeToWait);
            _navMeshAgent.speed = 3;
            _animator.SetTrigger("Walk");
            yield return new WaitForSeconds(timeToWait);
           //StartCoroutine(AutorizeMove());
        }
        else
        {
            yield return new WaitForSeconds(4);
            //StartCoroutine(AutorizeMove());
        }
    }

    IEnumerator ATTEND()
    {
        yield return new WaitForSeconds(0.3f);
        StartCoroutine(MoveManager());
    }
}