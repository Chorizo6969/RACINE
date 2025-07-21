using UnityEngine;

/// <summary>
/// Classe m�re des classes de jobs
/// </summary>
public abstract class JobAbility : MonoBehaviour
{
    public virtual void OnJobAssign() { }

    public abstract void UseAbility();
}
