using UnityEngine;

public class Déchet2 : MonoBehaviour
{
    private void Start()
    {
        Affichage();
    }
    public void Incremente()
    {
        if (IntroManager.Instance.bouliste)
        {
            IntroManager.Instance.id++;
            Affichage();
            Destroy(GetComponent<Déchet2>());
        }
    }
    private void Affichage()
    {
        Debug.Log(IntroManager.Instance.id);
    }
}
