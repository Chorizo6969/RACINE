using UnityEngine;

public class Mineur : Recolteur
{
    #region Singleton
    public static Mineur Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public override void UseAbility()
    {
        base.UseAbility();
        foreach (HumanPlants human in ActorInJob)
        {
            human.HumanMotorsRef.GoTo(JobTransform.position);
        }
    }
}
