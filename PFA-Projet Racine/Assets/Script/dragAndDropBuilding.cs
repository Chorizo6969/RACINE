using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class dragAndDropBuilding : MonoBehaviour
{
    public GameObject BOUGE;
    public Ray ray;
    public bool tonDaron;
    public bool hasClickOnBuildingButtonInstance;
    private Vector3 _startPos;

    private void Start()
    {
        _startPos = transform.position;
    }

    public void OnLeftClick(InputAction.CallbackContext callBackContext)
    {
        if (callBackContext.started)
        {
            tonDaron = true;
            if (BOUGE != null)
            {
                
                
            }
        }
        if (callBackContext.canceled)
        {
            hasClickOnBuildingButtonInstance = false;
            BOUGE = null;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (hasClickOnBuildingButtonInstance)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            Physics.Raycast(ray, out hitInfo);
            if (BOUGE != null)
            {
                if (hitInfo.collider != null)
                {
                    if (hitInfo.collider.tag == "tile")
                    {
                        BOUGE.transform.position = new Vector3(hitInfo.point.x, hitInfo.point.y, hitInfo.point.z);
                    }
                }
            }
            Debug.DrawRay(ray.origin, ray.direction*50, Color.red);
        }
    }

    IEnumerator ATTEND()
    {
        yield return new WaitForSeconds(0.01f);
        Cursor.lockState = CursorLockMode.None;
    }

    public void ClickOnButtonInstancier()
    {
        hasClickOnBuildingButtonInstance = true;
        transform.position = _startPos;
        Cursor.lockState = CursorLockMode.Locked;
        StartCoroutine(ATTEND());
        BOUGE.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        BOUGE.transform.position += new Vector3(0, 0.7f, 0);
    }
}