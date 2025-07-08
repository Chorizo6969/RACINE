using UnityEngine;

public class BuildingBase : MonoBehaviour
{
    public BuildingData Data { get; set; } // The data associated with this building, including its mesh, size, cost, and other properties.
    public MeshFilter MeshFilter { get; private set; } // The mesh filter component used to render the building's mesh.
    public MeshRenderer MeshRenderer { get; private set; } // The mesh renderer component used to render the building's mesh.

    protected int _currentPopulation; // The current population supported by this building.

    private void Awake()
    {
        MeshFilter = GetComponent<MeshFilter>();
        MeshRenderer = GetComponent<MeshRenderer>();
    }
}
