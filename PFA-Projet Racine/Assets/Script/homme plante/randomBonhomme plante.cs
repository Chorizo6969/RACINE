using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomBonhommePlant : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject listOwner;
    private bool _canMove;
    private Vector3 _positionToGo;
    private NavMeshAgent _navMeshAgent;

    [SerializeField]
    private Animator _animator;

    void Start()
    {
        StartCoroutine(ATTEND());
    }

    public void Update()
    {
        /*if (GetComponent<IA>().IsEnExpedition)
        {
            _navMeshAgent.speed = 3;
        }*/
    }

    IEnumerator FindRandomPositionToGo()
    {
        List<GameObject> list = listOwner.GetComponent<wayPointPosManager>().WayPoints;

        _positionToGo = FindDirection(gameObject, list[Random.Range(0, list.Count)]);
        if (!GetComponent<HideNSeek>().IsHiding && !GetComponent<IA>().IsEnExpedition)
        {
            _navMeshAgent.SetDestination(_positionToGo);
        }
        yield return new WaitForSeconds(Random.Range(2, 7));
        StartCoroutine(FindRandomPositionToGo());
    }

    private Vector3 FindDirection(GameObject thisGO, GameObject targetDestination)
    {
        Vector3 direction = targetDestination.transform.position;
        //direction.y = 1;
        return direction;
    }

    public IEnumerator AutorizeMove()
    {
        if (GetComponent<HideNSeek>().IsHiding || GetComponent<IA>().IsEnExpedition)
        {
            if (Vector3.Distance(gameObject.transform.position, _positionToGo) <= 0.5f)
            {
                _navMeshAgent.speed = 0;
                yield return new WaitForSeconds(1);
                StartCoroutine(AutorizeMove());
            }
            else
            {
                _navMeshAgent.speed = 3;
                yield return new WaitForSeconds(1);
                StartCoroutine(AutorizeMove());
            }
        }
        else
        {
            _canMove = true;
            _navMeshAgent.speed = 3;
            int timeToWait = Random.Range(2, 5);
            yield return new WaitForSeconds(timeToWait);
            _canMove = false;
            _navMeshAgent.speed = 0;
            yield return new WaitForSeconds(timeToWait);
            StartCoroutine(AutorizeMove());
        }
    }

    IEnumerator ATTEND()
    {
        yield return new WaitForSeconds(0.1f);
        listOwner = wayPointPosManager.Instance.gameObject;
        _navMeshAgent = GetComponent<NavMeshAgent>();
        yield return new WaitForSeconds(3);
        StartCoroutine(FindRandomPositionToGo());
        StartCoroutine(AutorizeMove());
    }
}