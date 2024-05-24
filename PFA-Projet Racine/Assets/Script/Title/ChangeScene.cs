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
        _anim.Play();
        StartCoroutine(Delay());
    }

    public void Credits()
    {
        _id = 1;
        _anim.Play();
        StartCoroutine(Delay());
    }

    public void backmenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2.7f);
        if (_id == 1)
        {
            SceneManager.LoadScene("Credits");
        }
        else
        {
            SceneManager.LoadScene("Vrai Scene");
        }
    }
}
