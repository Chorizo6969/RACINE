using System.Collections.Generic;
using UnityEngine;

public class Recolteur : JobAbility
{
    [Range(0,1)] protected float _probaToForgetRessources = 0f;
    public Transform Reserve;
    public Animator AnimatorRecolteur;

    public List<HumanPlants> ActorInJob = new();
    public Transform TargetPoint;

    private void Start()
    {
        TimeInGame.Instance.OnStartWork += UseAbility;
    }

    public virtual void BringBackResources() //Ramène les ressources sur son dos jusqu'à la reserve la plus proche
    {

    }

    public override void UseAbility()
    {
    }
}
