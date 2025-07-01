using UnityEngine;

public class Job : MonoBehaviour
{
    public HumanJobSO CurrentJob;
    public bool IsJobing;

    private void Start()
    {
        TimeInGame.Instance.OnStartWork += SetJobTrue;
        TimeInGame.Instance.OnStartDiscuss += SetJobFalse;
    }

    private void SetJobTrue() { IsJobing = true; }
    private void SetJobFalse() { IsJobing = false; }
}