using UnityEngine;

public class ExpeditionManager : MonoBehaviour
{
    public static ExpeditionManager Instance;

    private void Awake()
    {
        Instance = this;
    }
}
