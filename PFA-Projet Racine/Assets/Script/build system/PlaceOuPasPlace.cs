using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceOuPasPlace : MonoBehaviour
{
    public bool isPlacable = true;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Water") || collision.gameObject.CompareTag("building") && gameObject.layer != 10)
        {
            isPlacable = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isPlacable = true;
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
            Debug.Log("PUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUTE");
        }
    }
}