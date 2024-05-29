using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using Unity.VisualScripting;
using UnityEditor.AI;
using UnityEngine;

public class TEST : MonoBehaviour
{
    public NavMeshSurface NavMeshSurface;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            NavMeshBuilder.BuildNavMesh();
            Debug.Log("build");
        }
    }
}