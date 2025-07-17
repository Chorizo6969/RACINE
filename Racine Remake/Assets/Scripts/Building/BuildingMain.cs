using UnityEngine;

public class BuildingMain : MonoBehaviour
{
    #region Initialization

    public BuildingBase Building { get; set; }
    public BuildingData Data { get; set; }
    public BoundsInt Area { get; set; }
    public MeshRenderer Render { get; private set; }
    public MeshFilter Filter { get; private set; }

    private void Awake()
    {
        Render = GetComponentInChildren<MeshRenderer>();
        Filter = GetComponentInChildren<MeshFilter>();
    }

    #endregion
}
