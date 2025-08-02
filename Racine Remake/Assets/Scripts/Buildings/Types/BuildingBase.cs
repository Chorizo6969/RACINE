using System.Collections.Generic;
using UnityEngine;

public abstract class BuildingBase : MonoBehaviour
{
    #region Initialization

    public BuildingData Data { get; set; }
    public BoxCollider Collider { get;private set; }
    public MeshRenderer Renderer { get; private set; }

    [field:SerializeField]
    public GameObject Base { get;private set; }

    public List<Cell> Placement { get; set; } = new();

    private void Awake()
    {
        Collider = Base.GetComponent<BoxCollider>();
        Renderer = Base.GetComponent<MeshRenderer>();
    }

    public virtual void Init() // Initialization method to call after instantiation.
    {
        BuildingManager.Instance.ReferenceBuilding(this);
    }

    #endregion

    public void ResetCells()
    {
        BuildingManager.Instance.ResetBuilding(this);
        Placement.ForEach(value => value.Building = null);
        Placement.Clear();
    }

    public virtual void Effect()
    {
        // This method can be overridden by derived classes to implement specific effects.
    }

    private void OnDestroy()
    {
        ResetCells();
    }
}
