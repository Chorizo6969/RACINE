using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceOuPasPlace : MonoBehaviour
{
    public bool isPlacable = true;

    private void Start()
    {
        if (gameObject.layer == 7)
        {
            isPlacable = false;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        /*if (gameObject.name == "Water_house" && collision.CompareTag("Water"))
        {

        }*/
        if (gameObject.layer != 7 && (collision.CompareTag("Water") || collision.CompareTag("building")))
        {
            isPlacable = false;
        }
        else if (gameObject.layer == 7 && collision.CompareTag("Water"))
        {
            isPlacable = true;
        }

        Debug.Log(collision.gameObject.tag);
    }

    private void OnTriggerExit(Collider other)
    {

        if (gameObject.layer == 7 && other.CompareTag("Water"))
        {
            isPlacable = false;
        }
        else if (other.CompareTag("Water") || other.CompareTag("building") && gameObject.layer != 7)
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
    }

    public void SetBox()
    {
        if (gameObject.name == "champ")
        {
            GetComponentInParent<BuildingCanvas>().gameObject.AddComponent<BoxCollider>();
        }
        else if (gameObject.name == "Water_house")
        {
            Destroy(gameObject.GetComponent<BoxCollider>());
            StartCoroutine(ATTENNNNNNNNNNNNND());
        }
    }

    IEnumerator ATTENNNNNNNNNNNNND()
    {
        yield return new WaitForSeconds(0.001f);
        gameObject.AddComponent<BoxCollider>();
    }
}