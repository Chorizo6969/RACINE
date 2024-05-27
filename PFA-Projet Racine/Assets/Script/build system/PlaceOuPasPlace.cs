using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceOuPasPlace : MonoBehaviour
{
    public bool isPlacable = true;
    public GameObject SecondBox;

    public Vector3 ColliderBoxSize1;
    public Vector3 ColliderBoxPosition1;

    public Vector3 ColliderBoxSize2;
    public Vector3 ColliderBoxPosition2;

    private void Start()
    {
        ColliderBoxSize1 = GetComponent<BoxCollider>().size;
        ColliderBoxPosition1 = GetComponent<BoxCollider>().center;

        ColliderBoxSize2 = new Vector3(7.00000095f, 6.99999952f, 10.0000019f);
        ColliderBoxPosition2 = new Vector3(0.148981839f, 1.43600392f, -1.7643292f);

        if (gameObject.layer == 7)
        {
            isPlacable = false;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (gameObject.layer != 7 && (collision.CompareTag("Water") || collision.CompareTag("building") || collision.CompareTag("forest") ))
        {
            isPlacable = false;
        }
        else if (gameObject.layer == 7 && collision.CompareTag("Water"))
        {
            if (SecondBox.GetComponent<CheckIfInGround>().IsInGround)
            {
                isPlacable = true;
            }
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (gameObject.layer != 7 && (collision.CompareTag("Water") || collision.CompareTag("building") || collision.CompareTag("forest") ))
        {
            isPlacable = false;
        }
        else if (gameObject.layer == 7 && collision.CompareTag("Water"))
        {
            

            if (SecondBox.GetComponent<CheckIfInGround>().IsInGround)
            {
                isPlacable = true;
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (gameObject.layer == 7 && other.CompareTag("Water"))
        {
            isPlacable = false;
        }
        else if (other.CompareTag("Water") || other.CompareTag("building") || other.CompareTag("forest") && gameObject.layer != 7)
        {
            

            isPlacable = true;
        }
    }

    private void Update()
    {
        if (isPlacable) 
        {
            GetComponentInParent<BuildingCanvas>().TrueMat();
        }
        else if (!isPlacable)
        {
            GetComponentInParent<BuildingCanvas>().FalseMat();
        }

        if (SecondBox != null)
        {
            if (!SecondBox.GetComponent<CheckIfInGround>().IsInGround)
            {
                isPlacable = false;
            }
        }
    }

    public void SetBox()
    {
        if (gameObject.name == "champ")
        {
            GetComponentInParent<BuildingCanvas>().gameObject.AddComponent<BoxCollider>();
        }
        else if (gameObject.name == "Water_house")
        {
            ChangeBoxSizeNormal();
        }
    }

    public void ChangeBoxSizeUp()
    {
        GetComponent<BoxCollider>().size = ColliderBoxSize1;
        GetComponent<BoxCollider>().center = ColliderBoxPosition1;
    }

    public void ChangeBoxSizeNormal()
    {
        GetComponent<BoxCollider>().size = ColliderBoxSize2;
        GetComponent<BoxCollider>().center = ColliderBoxPosition2;
    }
    IEnumerator ATTENNNNNNNNNNNNND()
    {
        yield return new WaitForSeconds(0.001f);
        gameObject.AddComponent<BoxCollider>();
    }
}