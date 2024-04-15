using UnityEngine;

/// <summary>
/// Script qui donne une graine à la souris
/// </summary>
public class GivePlant : MonoBehaviour
{
    /// <summary>
    /// Référence de la graine qui va être donné
    /// </summary>
    [SerializeField] private GameObject _seed;

    /// <summary>
    /// référence de la caméra
    /// </summary>
    [SerializeField] private GameObject _camera;

    /// <summary>
    /// attribue la graine définie à l'emplacement de graine de al caméra
    /// </summary>
    public void OnClick()
    {
        _camera.GetComponent<ClickFieldManager>().HumanSeed = _seed;
    }
}