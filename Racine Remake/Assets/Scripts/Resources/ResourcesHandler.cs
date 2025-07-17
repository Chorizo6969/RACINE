using System;

public static class ResourcesHandler
{
    public static event Action<WorldResources> OnResourcesUpdate;
    public static WorldResources MainResources = new();

    public static void AddResources(WorldResources resources)
    {
        MainResources.Wood += resources.Wood;
        MainResources.Rock += resources.Rock;
        MainResources.Water += resources.Water;

        OnResourcesUpdate?.Invoke(MainResources);
    }

    public static void RemoveResources(WorldResources resources)
    {
        MainResources.Wood -= resources.Wood;
        MainResources.Rock -= resources.Rock;
        MainResources.Water -= resources.Water;

        OnResourcesUpdate?.Invoke(MainResources);
    }

    public static void ResetResources()
    {
        MainResources.Wood = 0;
        MainResources.Rock = 0;
        MainResources.Water = 0;

        OnResourcesUpdate?.Invoke(MainResources);
    }

    public static bool HasEnoughResources(WorldResources resources)
    {
        return (MainResources.Wood >= resources.Wood && MainResources.Rock >= resources.Rock && MainResources.Water >= resources.Water);
    }
}
