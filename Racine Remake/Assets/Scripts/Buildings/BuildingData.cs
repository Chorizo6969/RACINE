using UnityEngine;

[CreateAssetMenu(fileName = "BuildingData", menuName = "ScriptableObjects/BuildingData", order = 1)]
public class BuildingData : ScriptableObject
{
    public BuildingData Upgrade;
    public GameObject BuildingPrefab;
    public WorldResources Cost;
    public Vector2Int Size;

    public string Name;
    public string Description;
    public int MaxPopulation;
    public WorldResources MaxCapacity;

}
