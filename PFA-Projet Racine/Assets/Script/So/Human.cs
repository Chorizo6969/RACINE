using UnityEngine;

[CreateAssetMenu(fileName = "HumanPlants", menuName = "Humains plantes", order = 1)]
public class Human : ScriptableObject
{
    /// <summary>
    /// Set the work of the human
    /// </summary>
    [field: SerializeField]
    public string Work { get;  set; }

    /// <summary>
    /// Set the sprite of the human
    /// </summary>
    [field: SerializeField]
    public GameObject Sprite { get; set; }
}
