using UnityEngine;

/// <summary>
/// value of the plant
/// </summary>
public class PlantShellValue : MonoBehaviour
{
    /// <summary>
    /// Amount of money given by the plant
    /// </summary>
    public int Value { get; private set; }

    private void Start()
    {
        Value = Random.Range(50, 150);
    }
}
