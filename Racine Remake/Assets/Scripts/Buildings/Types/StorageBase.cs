public abstract class StorageBase : BuildingBase
{
    public WorldResources CurrentCapacity => _currentCapacity;

    protected WorldResources _maxCapacity;
    protected WorldResources _currentCapacity;

    private void Start()
    {
        _maxCapacity = Data.MaxCapacity;
    }

    public bool StockRessources(WorldResources amount)
    {
        if (amount.Wood >= _maxCapacity.Wood || amount.Rock >= _maxCapacity.Rock || amount.Water >= _maxCapacity.Water) return false;

        _currentCapacity.Wood += amount.Wood;
        _currentCapacity.Rock += amount.Rock;
        _currentCapacity.Water += amount.Water;

        ResourcesHandler.RemoveResources(amount);

        return true;
    }

    public bool TakeRessources(WorldResources amount)
    {
        if (amount.Wood <= 0 || amount.Rock <= 0 || amount.Water <= 0) return false;

        _currentCapacity.Wood -= amount.Wood;
        _currentCapacity.Rock -= amount.Rock;
        _currentCapacity.Water -= amount.Water;

        ResourcesHandler.AddResources(amount);

        return true;
    }
}
