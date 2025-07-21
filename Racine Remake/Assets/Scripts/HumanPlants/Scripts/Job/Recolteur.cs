using UnityEngine;

public class Recolteur : JobAbility
{
    [Range(0,1)] protected float _probaToForgetRessources = 0f;
    protected Transform _reserve;
    protected Animator _animatorRecolteur;

    private void Start()
    {
        TimeInGame.Instance.OnStartWork += UseAbility;
    }

    public override void UseAbility()
    {

    }
}
