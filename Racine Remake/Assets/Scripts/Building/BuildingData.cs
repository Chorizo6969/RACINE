using UnityEngine;

[CreateAssetMenu(fileName = "Building Type", menuName = "Buildings")]
public class BuildingData : ScriptableObject
{
    public BuildingType Type;
    public BuildingData Upgrade;
    public WorldResources Cost;
    public Vector2Int Size;
    public Mesh Mesh;

    public string Name;
    public string Description;
}
