using UnityEngine;

public class Déchet2 : MonoBehaviour
{
    public void Incremente()
    {
        if (IntroManager.Instance.bouliste)
        {
            IntroManager.Instance.id++;
            Destroy(GetComponent<Déchet2>());
        }
    }
}
