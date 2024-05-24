using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField]
    private Animation _anim;
    [SerializeField]
    private int _id = 0;

    public void StartGame()
    {
        _id = 0;
        StartCoroutine(Delay());
    }

    public void Credits()
    {
        _id = 1;
        StartCoroutine(Delay());
    }

    public void backmenu()
    {
        _id = 2;
        StartCoroutine(Delay());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator Delay()
    {
        _anim.Play("CloseCercle");
        yield return new WaitForSeconds(2f);
        if (_id == 1)
        {
            SceneManager.LoadScene("Credits");
        }
        else if (_id == 2)
        {
            SceneManager.LoadScene("Menu");
        }
        else 
        {
            SceneManager.LoadScene("Vrai Scene");
        }
    }
}
