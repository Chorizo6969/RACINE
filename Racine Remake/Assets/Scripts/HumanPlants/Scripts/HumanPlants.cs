using UnityEngine;

public class HumanPlants : MonoBehaviour
{
    [Header("OtherDomain")]
    public Personality HumanPersonality;
    public Job HumanJob;
    public RelationShips HumanRelationShips;

    private void Start()
    {
        Chomage.Instance.SetupAgent(this.gameObject);
        TimeInGame.Instance.OnStartSleep += TimeToSleep;
    }

    private void TimeToSleep()
    {
        print("Dodo...");
    }
}
