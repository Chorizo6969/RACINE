using UnityEngine;
using static HumanEnum;

/// <summary>
/// Classe majeure, Attribue une routine ou non au humain plante (décide de si ils travaillent ou non)
/// </summary>
public class Job : MonoBehaviour
{
    public HumanJobSO CurrentJob; //pour les stats

    private HumanPlants _humanPlantsRef;

    private void Start()
    {
        _humanPlantsRef = this.gameObject.GetComponent<HumanPlants>();
        TimeInGame.Instance.OnStartWork += GoWork;
        TimeInGame.Instance.OnStartChomage += StartChomageRoutine;
        TimeInGame.Instance.OnStartDiscuss += StopWork;
    }

    private void IsSick() //Tout les matin, setup à faux...
    {
        _humanPlantsRef.StatsRef.IsSick = false;
        _humanPlantsRef.StatsRef.IsFakeSick = false;
        SickHuman.Instance.SickProba(ref _humanPlantsRef.StatsRef.IsSick, ref _humanPlantsRef.StatsRef.IsFakeSick, _humanPlantsRef.StatsRef.SickProba); //Malade ou pas...
    }

    private async void GoWork() 
    {
        IsSick();

        if (_humanPlantsRef.StatsRef.IsSick || _humanPlantsRef.StatsRef.IsFakeSick) //Si malade il reste chez lui pour la journée.
        {
            await _humanPlantsRef.BackHome();
            return;
        }
        else if (CurrentJob.JobType == HumanJobType.Défense)
        {
            await _humanPlantsRef.BackHome();
        }
        if (CurrentJob.JobName != HumanJobs.Chômeur && CurrentJob.JobType != HumanJobType.Récolteur)
        {
            _humanPlantsRef.HumanNoJobGestion.StartChill(); //Les autres métiers se balladent en attendant qu'ils se passent un truc
        }
    }

    private void StartChomageRoutine()
    {
        if(CurrentJob.JobName == HumanJobs.Chômeur)
        {
            _humanPlantsRef.HumanNoJobGestion.StartChill(); //Il commence la journée
        }
    }

    private void StopWork() 
    {
        _humanPlantsRef.HumanNoJobGestion.StopAllChillBehaviors();
        _humanPlantsRef.HumanMotorsRef.Agent.ResetPath();
    }
}