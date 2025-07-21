using System.Collections.Generic;
using UnityEngine;

public class Recolteur : JobAbility
{
    [Range(0,1)] protected float _probaToForgetRessources = 0f;
    public Animator AnimatorRecolteur;

    public List<HumanPlants> ActorInJob = new();
    public Transform JobTransform;

    private void Start()
    {
        TimeInGame.Instance.OnStartWork += UseAbility;
    }

    public override void UseAbility()
    {
    }
}
