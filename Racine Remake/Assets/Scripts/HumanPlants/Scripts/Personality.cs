using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static HumanEnum;

/// <summary>
/// Ce scirpt va stocker la personalit� de l'humain plante et ajouter le script de cette derni�re.
/// </summary>
public class Personality : MonoBehaviour
{
    public HumanPersonalitySO HumanPersonalityRef;
    [SerializeField] private List<HumanPersonalitySO> _allPersonality = new();
    [SerializeField] private Stats _stats;

    public event Action OnStatsReady;

    private void Start() 
    {
        ChooseAPersonality();
    }

    private async void ChooseAPersonality()
    {
        int indexChoose = UnityEngine.Random.Range(0, _allPersonality.Count - 1);

        HumanPersonalityRef = _allPersonality[indexChoose];
        await _stats.Setup(HumanPersonalityRef);

        SetupSomePersonality();

        OnStatsReady.Invoke();
    }

    private async void SetupSomePersonality()
    {
        if (HumanPersonalityRef.PersonalityName is HumanPersonality.BonVivant) { await Happiness.Instance.BuffHappiness(_stats.HappinessFlat); } //Attribution bonheur
        else if (HumanPersonalityRef.PersonalityName is HumanPersonality.MoteurFeuillu or HumanPersonality.Surpoids) { GetComponent<NavMeshAgent>().speed = _stats.SpeedHuman; } //attribution speed
        else if (HumanPersonalityRef.PersonalityName is HumanPersonality.Crapophage or HumanPersonality.FanDeCrotte) { GetComponent<PoopDetector>().enabled = true; }
        else if (HumanPersonalityRef.PersonalityName is HumanPersonality.Narcoleptique) { GetComponent<Narcoleptique>().enabled = true; }
    }
}
