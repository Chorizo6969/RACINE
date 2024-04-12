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


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RandomizeWaypointPos());
    }

    IEnumerator RandomizeWaypointPos()
    {
        foreach (GameObject wayPoint in WayPoints)
        {
            wayPoint.transform.position = new Vector3(Random.Range(minX, maxX), wayPoint.transform.position.y, Random.Range(minZ, maxZ));
        }
        yield return new WaitForSeconds(10); StartCoroutine(RandomizeWaypointPos());
    }
}