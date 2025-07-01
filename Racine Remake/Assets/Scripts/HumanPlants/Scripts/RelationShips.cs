using UnityEngine;

public class RelationShips : MonoBehaviour
{
    private void Start()
    {
        TimeInGame.Instance.OnStartDiscuss += GoTalk;
    }
    
    public void GoTalk()
    {
        print("Il faut papoter !");
    }
}
