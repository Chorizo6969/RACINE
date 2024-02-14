using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public List<GameObject> waypoints;
    public float speed = 2;
    public bool isLoop = true;
    int index = 0;

    private void Update()
    {
        Vector3 destination = waypoints[index].transform.position;
        Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        transform.position = newPos;

        float distance = Vector3.Distance(transform.position, destination);
        if (distance <= 0.05)
        {
            if (index <= waypoints.Count - 1)
            {
                index++;
            }
            else
            {
                if (isLoop)
                {
                    index = 0;
                }
            }
        }
    }
}
