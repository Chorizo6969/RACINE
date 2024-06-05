using UnityEngine;

public class Leroidesdéchets : MonoBehaviour
{
    public static Leroidesdéchets instance;

    private void Awake()
    {
        instance = this;
    }
    public void Incremente()
    {
        IntroManager.Instance.id++;
    }
}
