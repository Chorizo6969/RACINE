using UnityEngine;

public abstract class HomeBase : BuildingBase
{
    protected GameObject[] _occupants;
    protected int _occupantsCount;

    public override void Init()
    {
        base.Init();
        _occupants = new GameObject[Data.MaxPopulation];
    }

    public bool AssignHome(GameObject pnj) // Fills the house with pnjs.
    {
        if (_occupantsCount >= Data.MaxPopulation) return false;

        _occupants[_occupantsCount] = pnj;
        _occupantsCount++;
        return true;
    }
}
