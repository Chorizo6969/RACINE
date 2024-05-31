using UnityEngine;

public class Déchet3 : MonoBehaviour
{
    public void Incremente()
    {
        if (IntroManager.Instance.bouliste && IntroManager.Instance.id == 5)
        {
            IntroManager.Instance.id++;
            Destroy(GetComponent<Déchet2>());
        }
    }
}
