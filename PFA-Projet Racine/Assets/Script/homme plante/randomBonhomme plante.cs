using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToRandomPosition : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject listOwner;
    private bool _canMove;
    private Vector3 _positionToGo;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ATTEND());
    }

    public void Update()
    {
        if (_canMove)
        {
            Vector3 _directionToGo = Vector3.MoveTowards(transform.position, _positionToGo, speed * Time.deltaTime);
            transform.position = _directionToGo;
        }
    }

    IEnumerator FindRandomPositionToGo()
    {
        List<GameObject> list = listOwner.GetComponent<wayPointPosManager>().WayPoints;
        _positionToGo = FindDirection(gameObject, list[Random.Range(0, list.Count)]);

        //_positionToGo.Normalize();
        

        yield return new WaitForSeconds(Random.Range(2, 7));
        StartCoroutine(FindRandomPositionToGo());
    }

    private Vector3 FindDirection(GameObject thisGO, GameObject targetDestination)
    {
        Vector3 direction = targetDestination.transform.position - thisGO.transform.position;
        direction.y = 1;
        return direction;
    }

    IEnumerator AutorizeMove()
    {
        _canMove = true;
        int timeToWait = Random.Range(2, 5);
        yield return new WaitForSeconds(timeToWait);
        _canMove = false; yield return new WaitForSeconds(timeToWait);
        StartCoroutine(AutorizeMove());
    }

    IEnumerator ATTEND()
    {
        yield return new WaitForSeconds(3);
        StartCoroutine(FindRandomPositionToGo());
        StartCoroutine(AutorizeMove());
    }
}