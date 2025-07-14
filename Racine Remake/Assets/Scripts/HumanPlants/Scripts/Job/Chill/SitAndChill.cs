using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Classe qui fait en sorte que l'humain plante regarde autour de lui pendant un moment
/// </summary>
public class SitAndChill : NoJobGestion
{
    public void SitDownAndChill()
    {
        _humanPlants.HumanMotorsRef.Agent.ResetPath();
    }
}
