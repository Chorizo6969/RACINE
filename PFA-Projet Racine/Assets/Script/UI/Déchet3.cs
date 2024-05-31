using UnityEngine;

public class Déchet3 : MonoBehaviour
{
    private void Start()
    {
        Affichage();
    }
    public void Incremente()
    {
        if (IntroManager.Instance.bouliste && IntroManager.Instance.id == 5)
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
