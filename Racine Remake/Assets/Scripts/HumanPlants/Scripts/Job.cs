using UnityEngine;
using UnityEngine.AI;
using static HumanEnum;

/// <summary>
/// Classe majeure, Attribue une routine ou non au humain plante (d�cide de si ils travaillent ou non)
/// </summary>
public class Job : MonoBehaviour
{
    [HideInInspector] public HumanJobSO CurrentJob;

    private HumanPlants _humanPlantsRef;

    private void Start()
    {
        _humanPlantsRef = this.gameObject.GetComponent<HumanPlants>();
        TimeInGame.Instance.OnStartWork += GoWork;
        TimeInGame.Instance.OnStartChomage += StartChomageRoutine;
        TimeInGame.Instance.OnStartDiscuss += StopWork;
    }

    private void IsSick() //Tout les matin, setup � faux...
    {
        _humanPlantsRef.StatsRef.IsSick = false;
        _humanPlantsRef.StatsRef.IsFakeSick = false;
        SickHuman.Instance.SickProba(ref _humanPlantsRef.StatsRef.IsSick, ref _humanPlantsRef.StatsRef.IsFakeSick, _humanPlantsRef.StatsRef.SickProba); //Malade ou pas...
    }

    private async void GoWork() 
    {
        IsSick();

        if (_humanPlantsRef.StatsRef.IsSick || _humanPlantsRef.StatsRef.IsFakeSick) //Si malade il reste chez lui pour la journ�e.
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
            _humanPlantsRef.HumanNoJobGestion.StartChill(); //Les autres m�tiers se balladent en attendant qu'ils se passent un truc
        }
    }

    private void StartChomageRoutine()
    {
        if(CurrentJob.JobName == HumanJobs.Ch�meur)
        {
            //EnableBalladeSystem();
            _humanPlantsRef.HumanNoJobGestion.StartChill(); //Il commence la journ�e
        }
    }

    private void StopWork() 
    {
        _humanPlantsRef.HumanNoJobGestion.StopAllChillBehaviors();
        //DisableBalladeSystem();
        _humanPlantsRef.HumanMotorsRef.Agent.ResetPath();
    }
}