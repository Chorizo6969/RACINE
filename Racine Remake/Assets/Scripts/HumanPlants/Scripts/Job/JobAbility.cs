using UnityEngine;

public abstract class JobAbility : MonoBehaviour
{
    public virtual void OnJobAssign() { }

    public abstract void UseAbility();
}
