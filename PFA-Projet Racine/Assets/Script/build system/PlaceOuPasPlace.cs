using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceOuPasPlace : MonoBehaviour
{


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("water") && gameObject.layer != 10)
        {

        }
    }
}