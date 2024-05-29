using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceOuPasPlace : MonoBehaviour
{
    public bool isPlacable = true;
    public GameObject SecondBox;

    [SerializeField] private List<CheckIfInGround> _checkIfInGrounds = new();

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

    //private void OnTriggerEnter(Collider collision)
    //{
    //    if (gameObject.layer != 7 && (collision.CompareTag("Water") || collision.CompareTag("building") || collision.CompareTag("forest") ))
    //    {
    //        isPlacable = false;
    //    }
    //    else if (gameObject.layer == 7 && collision.CompareTag("Water"))
    //    {
    //        if (SecondBox.GetComponent<CheckIfInGround>().IsInGround)
    //        {
    //            isPlacable = true;
    //        }
    //    }
    //}

    //private void OnTriggerStay(Collider collision)
    //{
    //    if (gameObject.layer != 7 && (collision.CompareTag("Water") || collision.CompareTag("building") || collision.CompareTag("forest") ))
    //    {
    //        isPlacable = false;
    //    }
    //    else if (gameObject.layer == 7 && collision.CompareTag("Water"))
    //    {

    //        if (SecondBox.GetComponent<CheckIfInGround>().IsInGround)
    //        {
    //            Debug.Log("3");
    //            isPlacable = true;
    //        }

    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{

    //    if (gameObject.layer == 7 && other.CompareTag("Water"))
    //    {
    //        isPlacable = false;
    //    }
    //    else if (other.CompareTag("Water") || other.CompareTag("building") || other.CompareTag("forest") && gameObject.layer != 7)
    //    {


    //        isPlacable = true;
    //    }
    //}

    private void Update()
    {
        isPlacable = IsPlacableFunc();
        if (IsPlacableFunc()) 
        {
            GetComponentInParent<BuildingCanvas>().TrueMat();
        }
        else
        {
            GetComponentInParent<BuildingCanvas>().FalseMat();
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

    bool IsPlacableFunc()
    {
        foreach (CheckIfInGround checkIfInGround in _checkIfInGrounds)
        {
            if (!checkIfInGround.IsInGround) return false;
        }
        return true;
    }

    IEnumerator ATTENNNNNNNNNNNNND()
    {
        yield return new WaitForSeconds(0.001f);
        gameObject.AddComponent<BoxCollider>();
    }
}