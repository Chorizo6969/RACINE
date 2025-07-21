using UnityEngine;

/// <summary>
/// Classe mère des classes de job.s
/// </summary>
public abstract class JobAbility : MonoBehaviour
{
    public virtual void OnJobAssign() { }

    public abstract void UseAbility();
}
