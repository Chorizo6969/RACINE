using UnityEngine;
using UnityEngine.AI;
using static HumanEnum;

public class Job : MonoBehaviour
{
    [HideInInspector] public HumanJobSO CurrentJob;

    [Header("System Chill")]
    [SerializeField] private NoJobGestion _noJobGestion;

    private HumanPlants _humanPlantsRef;
    private NavMeshAgent _agent;

    private void Start()
    {
        _humanPlantsRef = this.gameObject.GetComponent<HumanPlants>();
        _agent = this.gameObject.GetComponent<NavMeshAgent>();
        TimeInGame.Instance.OnStartWork += GoWork;
        TimeInGame.Instance.OnStartChomage += StartChomageRoutine;
        TimeInGame.Instance.OnStartDiscuss += StopWork;
    }

    private async void GoWork() 
    {
        if (CurrentJob.JobType == HumanJobType.R�colteur)
        {
            //DisableBalladeSystem(); //Plus besoin car plus de ballade
        }
        else if (CurrentJob.JobType == HumanJobType.D�fense)
        {
            await _humanPlantsRef.BackHome();
        }
        if (CurrentJob.JobName != HumanJobs.Ch�meur && CurrentJob.JobType != HumanJobType.R�colteur)
        {
            //EnableBalladeSystem();
            _noJobGestion.StartChill(); //Les autres m�tiers se balladent en attendant qu'ils se passent un truc
        }
    }

    private void StartChomageRoutine()
    {
        if(CurrentJob.JobName == HumanJobs.Ch�meur)
        {
            //EnableBalladeSystem();
            _noJobGestion.StartChill(); //Il commence la journ�e
        }
    }

    private void StopWork() 
    {
        _noJobGestion.StopAllChillBehaviors();
        //DisableBalladeSystem();
        _agent.ResetPath();
    }
}