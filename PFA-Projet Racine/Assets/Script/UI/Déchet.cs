using UnityEngine;

public class Déchet : MonoBehaviour
{
    public void Incremente()
    {
        IntroManager.Instance.id ++;
        Destroy(GetComponent<Déchet>());
    }
}
