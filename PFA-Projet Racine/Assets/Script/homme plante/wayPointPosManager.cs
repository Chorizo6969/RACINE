using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wayPointPosManager : MonoBehaviour
{
    [field : SerializeField] public List<GameObject> WayPoints {  get; private set; }
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minZ;
    [SerializeField] private float maxZ;

    public static wayPointPosManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitBeforeTrueStart());
    }

    IEnumerator RandomizeWaypointPos()
    {
        foreach (GameObject wayPoint in WayPoints)
        {
            wayPoint.transform.position = new Vector3(this.gameObject.transform.position.x + Random.Range(minX, maxX), wayPoint.transform.position.y, this.gameObject.transform.position.z + Random.Range(minZ, maxZ));
            StartCoroutine(CheckIfDebilosCanGoHere(wayPoint));
        }
        yield return new WaitForSeconds(10); StartCoroutine(RandomizeWaypointPos());
    }

    IEnumerator CheckIfDebilosCanGoHere(GameObject _debilos)
    {
        yield return new WaitForSeconds(0.2f);
        if (_debilos.GetComponent<CheckIfInGround>().IsInGround)
        {
            yield return new WaitForSeconds(0);
        }
        else
        {
            _debilos.transform.position = new Vector3(this.gameObject.transform.position.x + Random.Range(minX, maxX), _debilos.transform.position.y, this.gameObject.transform.position.z + Random.Range(minZ, maxZ));
            StartCoroutine(WaitBeforeReCheck(_debilos));
        }
    }

    IEnumerator WaitBeforeTrueStart()
    {
        yield return new WaitForSeconds(1f);
        StartCoroutine(RandomizeWaypointPos());
    }

    IEnumerator WaitBeforeReCheck(GameObject _debilos)
    {
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(CheckIfDebilosCanGoHere(_debilos));
    }
}