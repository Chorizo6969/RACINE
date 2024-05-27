using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfInGround : MonoBehaviour
{
    public bool IsInGround;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);

        if (other.CompareTag("tile"))
        {
            IsInGround = true;
        }
        else
        {
            IsInGround = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("tile"))
        {
            IsInGround = true;
        }
        else
        {
            IsInGround = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        IsInGround = false;
    }
}
