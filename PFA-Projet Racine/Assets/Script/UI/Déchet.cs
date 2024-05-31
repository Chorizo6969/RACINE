using UnityEngine;

public class Déchet : MonoBehaviour
{
    private void Start()
    {
        Affichage();
    }
    public void Incremente()
    {
        IntroManager.Instance.id ++;
        Affichage();
        Destroy(GetComponent<Déchet>());
    }
    private void Affichage()
    {
        Debug.Log(IntroManager.Instance.id);
    }
}
