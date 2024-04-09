using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class dragAndDropBuilding : MonoBehaviour
{
    public GameObject BOUGE;
    public Ray ray;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        Physics.Raycast(ray, out hitInfo);
        if (BOUGE != null)
        {
            if (hitInfo.collider.tag == "tile")
            {
                BOUGE.transform.position = new Vector3(hitInfo.point.x, hitInfo.point.y, hitInfo.point.z);
            }
        }
        //Debug.DrawRay(ray.origin, ray.direction*50, Color.red);
    }
}
