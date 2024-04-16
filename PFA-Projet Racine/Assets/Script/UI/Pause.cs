using UnityEngine;

/// <summary>
/// Script qui permet de controller le temps (rien que ça, ouais)
/// </summary>
public class Pause : MonoBehaviour
{
    /// <summary>
    /// Fonction qui arrête le temps
    /// </summary>
    public void Stop()
    {
        Time.timeScale = 0;
    }

    /// <summary>
    /// Fonction qui reprends le cours de temps
    /// </summary>
    public void Go()
    {
        Time.timeScale = 1;
    }
}
