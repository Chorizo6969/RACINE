using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Classe qui fait retourner l'humain plante chez lui.
/// </summary>
public class BackHouseForChill : NoJobGestion
{
    public async UniTask BackHome()
    {
        print("je vais chill chez moi");
        _humanPlants.HumanMotorsRef.GoTo(_humanPlants.Maison.gameObject);
        while (Vector3.Distance(_humanPlants.transform.position, _humanPlants.Maison.position) > _humanPlants.HumanMotorsRef.Agent.stoppingDistance + 1.7f)
        {
            await UniTask.Yield();
        }
        _humanPlants.StatsRef.IsHome = true;
    }
}