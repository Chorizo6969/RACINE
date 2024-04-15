using UnityEngine;

/// <summary>
/// Scriptable object des humains plantes.
/// </summary>
[CreateAssetMenu(fileName = "HumanPlants", menuName = "Humains plantes", order = 1)]
public class Human : ScriptableObject
{
    /// <summary>
    /// Variable string qui permet d'attribuer un métier à un humain plante
    /// </summary>
    [field: SerializeField]
    public string Work { get;  set; }

    /// <summary>
    /// Permet de changer le Mesh d'un humain plante.
    /// </summary>
    [field: SerializeField]
    public GameObject Sprite { get; set; }
}
