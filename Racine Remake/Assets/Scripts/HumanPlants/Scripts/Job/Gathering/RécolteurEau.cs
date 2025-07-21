using System.Collections.Generic;
using UnityEngine;

public class RécolteurEau : Recolteur
{

    #region Singleton
    public static RécolteurEau Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    public override void UseAbility()
    {
        base.UseAbility();
        foreach(HumanPlants human in ActorInJob)
        {
            human.HumanMotorsRef.GoTo(TargetPoint.position);
            //StartAnimation ou script de balade random dans l'eau
        }
    }

    public override void BringBackResources()
    {
        base.BringBackResources();
    }
}
