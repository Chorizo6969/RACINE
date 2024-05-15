using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private IA ia;

    public void Woodcutter()
    {
        //Vector3 vitesse = ia.GetComponent<Rigidbody>().velocity;
        float speed = ia._agent.velocity.magnitude;
        Debug.Log(speed);
        //animator.SetFloat("Speed", speed);
    }
}
