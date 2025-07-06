using UnityEngine;

/// <summary>
/// Classe m�re des classes de job.s
/// </summary>
public abstract class JobAbility : MonoBehaviour
{
    [SerializeField] protected HumanJobSO _jobSO;

    private void Start()
    {
        TimeInGame.Instance.OnStartWork += UseAbility;
    }

    public virtual void OnJobAssign() { }

    public abstract void UseAbility();
}
