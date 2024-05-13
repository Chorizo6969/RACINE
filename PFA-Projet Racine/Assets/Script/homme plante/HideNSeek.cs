using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HideNSeek : MonoBehaviour
{
    [SerializeField] private GameObject HidePointListOwner;

    private NavMeshAgent _naveshAgent;

    //private MoveToRandomPosition _moveToRandomPosition;

    [SerializeField] bool _isWorking;
    public bool _startHiding; //(var tempo) ou pas
    [field : SerializeField] public bool IsHiding { get; private set; }

    private void Awake()
    {
        HidePointListOwner = HidePointList.instance.gameObject;
    }

    private void Start()
    {
        _naveshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_startHiding && !IsHiding)
        {
            FindHidePoint();
        }
        else if (_startHiding && IsHiding)
        {
            _startHiding = false;
            IsHiding = false;
            _naveshAgent.speed = 0;
        }
    }

    public void FindHidePoint()
    {
        List<GameObject> list = HidePointListOwner.GetComponent<HidePointList>().HidePointsList;

        if (list.Count > 0)
        {
            _startHiding = false;
            IsHiding = true;
            _naveshAgent.speed = 3;
            _naveshAgent.SetDestination(list[Random.Range(0, list.Count)].transform.position);
        }
    }
}