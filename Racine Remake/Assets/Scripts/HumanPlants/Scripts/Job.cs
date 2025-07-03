using Cysharp.Threading.Tasks;
using UnityEngine;
using static HumanEnum;

public class Job : MonoBehaviour
{
    [HideInInspector] public HumanJobSO CurrentJob;

    [Header("System Chill")]
    [SerializeField] private NoJobGestion _noJobGestion;
    [SerializeField] private RandomBallade _randomBalladeRef;
    [SerializeField] private SitAndChill _sitAndChill;

    private HumanPlants _humanPlantsRef;

    private void Start()
    {
        _humanPlantsRef = this.gameObject.GetComponent<HumanPlants>();
        TimeInGame.Instance.OnStartWork += GoWork;
        TimeInGame.Instance.OnStartChomage += StartChomageRoutine;
        TimeInGame.Instance.OnStartDiscuss += StopWork;
        TimeInGame.Instance.OnStartSleep += StartSleepRound;
    }

    private async void GoWork() 
    {
        EnableBalladeSystem();
        _noJobGestion.CanChill = true;
        if (CurrentJob.JobType == HumanJobType.Récolteur)
        {
            DisableBalladeSystem(); //Plus besoin car plus de balade
        }
        else if (CurrentJob.JobType == HumanJobType.Défense)
        {
            await _humanPlantsRef.BackHome();
            print(gameObject.name);
            _noJobGestion.ChooseState().Forget();
        }
        else if (CurrentJob.JobName != HumanJobs.Chômeur)
        {
            print(gameObject.name);
            _noJobGestion.ChooseState().Forget(); //Les autres métiers se balladent en attendant qu'ils se passent un truc
        }
    }

    private void StartChomageRoutine()
    {
        if(CurrentJob.JobName == HumanJobs.Chômeur)
        {
            print(gameObject.name);
            _noJobGestion.ChooseState().Forget(); //Il commence la journée
        }
    }

    private void StopWork() 
    {
        _noJobGestion.CanChill = false;
    }

    private void StartSleepRound()
    {
        //if (CurrentJob.JobType == HumanJobType.Défense) //Tempo car fera partie de la fiche métier plus tard
        //{
        //    _noJobGestion.CanChill = true;
        //    _noJobGestion.ChooseState().Forget();
        //}
    }

    private void DisableBalladeSystem()
    {
        _noJobGestion.enabled = false;
        _randomBalladeRef.enabled = false;
        _sitAndChill.enabled = false;
    }

    private void EnableBalladeSystem()
    {
        _noJobGestion.enabled = true;
        _randomBalladeRef.enabled = true;
        _sitAndChill.enabled = true;
    }
}