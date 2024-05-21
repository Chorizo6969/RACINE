using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToRandomPosition : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject listOwner;
    private bool _canMove;
    private Vector3 _positionToGo;
    private NavMeshAgent _navMeshAgent;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ATTEND());
        Debug.Log("Start");
    }

    public void Update()
    {
        /*if (_canMove && !GetComponent<HideNSeek>().IsHiding)
        {
            Vector3 _directionToGo = Vector3.MoveTowards(transform.position, _positionToGo, speed * Time.deltaTime);
            transform.position = _directionToGo;
        }*/
    }

    IEnumerator FindRandomPositionToGo()
    {
        Debug.Log("Find New Point");

        List<GameObject> list = listOwner.GetComponent<wayPointPosManager>().WayPoints;

        _positionToGo = FindDirection(gameObject, list[Random.Range(0, list.Count)]);
        Debug.Log(_positionToGo);
        Debug.Log(!GetComponent<HideNSeek>().IsHiding && !GetComponent<IA>().IsEnExpedition);
        if (!GetComponent<HideNSeek>().IsHiding && !GetComponent<IA>().IsEnExpedition)
        {
            _navMeshAgent.SetDestination(_positionToGo);
            Debug.Log("GO");
        }

        yield return new WaitForSeconds(Random.Range(2, 7));
        StartCoroutine(FindRandomPositionToGo());
    }

    private Vector3 FindDirection(GameObject thisGO, GameObject targetDestination)
    {
        Vector3 direction = targetDestination.transform.position - thisGO.transform.position;
        //direction.y = 1;
        return direction;
    }

    IEnumerator AutorizeMove()
    {
        if (!GetComponent<HideNSeek>().IsHiding && !GetComponent<IA>().IsEnExpedition)
        {
            _canMove = true;
            _navMeshAgent.speed = 1;
            int timeToWait = Random.Range(2, 5);
            yield return new WaitForSeconds(timeToWait);
            _canMove = false;
            _navMeshAgent.speed = 0;
            yield return new WaitForSeconds(timeToWait);
            StartCoroutine(AutorizeMove());
        }
        else
        {
            yield return new WaitForSeconds(1);
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