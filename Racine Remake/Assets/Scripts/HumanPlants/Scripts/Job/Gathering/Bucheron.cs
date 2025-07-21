using UnityEngine;

public class Bucheron : Recolteur
{
    #region Singleton
    public static Bucheron Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public override void UseAbility()
    {
        base.UseAbility();
    }

    public override void BringBackResources()
    {
        base.BringBackResources();
    }
}
