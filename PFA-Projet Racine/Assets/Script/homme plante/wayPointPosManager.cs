using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wayPointPosManager : MonoBehaviour
{
    public List<GameObject> wayPoints;
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(randomizeWaypointPos());
    }

    IEnumerator randomizeWaypointPos()
    {
        foreach (GameObject wayPoint in wayPoints)
        {
            wayPoint.transform.position = new Vector3(Random.Range(minX, maxX), wayPoint.transform.position.y, Random.Range(minZ, maxZ));
        }

        yield return new WaitForSeconds(10); StartCoroutine(randomizeWaypointPos());
    }
}
