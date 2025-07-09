using UnityEngine;
using UnityEngine.AI;
using static HumanEnum;

/// <summary>
/// Classe majeure, Attribue une routine ou non au humain plante (d�cide de si ils travaillent ou non)
/// </summary>
public class Job : MonoBehaviour
{
    [HideInInspector] public HumanJobSO CurrentJob;

    [Header("System Chill")]
    [SerializeField] private NoJobGestion _noJobGestion;

    [Header("Stats")]
    [SerializeField] private Stats _stats;

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

    private void IsSick() //Tout les matin, setup � faux...
    {
        _stats.IsSick = false;
        _stats.IsFakeSick = false;
        SickHuman.Instance.SickProba(ref _stats.IsSick, ref _stats.IsFakeSick, _stats.SickProba); //Malade ou pas...
    }

    private async void GoWork() 
    {
        IsSick();

        if (_stats.IsSick || _stats.IsFakeSick) //Si malade il reste chez lui pour la journ�e.
        {
            await _humanPlantsRef.BackHome();
            return;
        }

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