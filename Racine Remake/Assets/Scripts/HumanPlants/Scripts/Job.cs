using UnityEngine;

public class Job : MonoBehaviour
{
    [SerializeField] private HumanJobSO _job;

    void Start()
    {
        AttributeComportement.AddComportementHuman(_job.ComponentName, this.gameObject); //Ajoute chomage
    }
}