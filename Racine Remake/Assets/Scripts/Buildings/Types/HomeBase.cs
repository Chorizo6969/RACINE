public abstract class HomeBase : BuildingBase
{
    protected HumanPlants[] _occupants;
    protected int _occupantsCount;

    public override void Init()
    {
        base.Init();
        _occupants = new HumanPlants[Data.MaxPopulation];
    }

    public bool AssignHome(HumanPlants pnj) // Fills the house with pnjs.
    {
        if (_occupantsCount >= Data.MaxPopulation) return false;

        _occupants[_occupantsCount] = pnj;
        _occupantsCount++;
        return true;
    }
}
