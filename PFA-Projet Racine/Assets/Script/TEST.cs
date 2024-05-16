using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Enter " + collision.gameObject.name);
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("Stay " + collision.gameObject.name);

        if (collision.gameObject.name == "Cube (1)" &&  collision.gameObject.name == "Cube (2)")
        {
            Debug.Log("NOUNOURS");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Exit " + collision.gameObject.name);
    }
}