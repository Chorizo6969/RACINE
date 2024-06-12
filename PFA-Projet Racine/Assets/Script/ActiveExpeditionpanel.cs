using System.Collections;
using UnityEngine;

public class ActiveExpeditionpanel : MonoBehaviour
{
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private ChangeColor changecolor;
    private bool _iswaiting;


    public void DesactivationPanel()
    {
        Debug.Log(changecolor.youCanWork);
        if (!_iswaiting && changecolor.youCanWork)
        {
            panel.SetActive(true);
            StartCoroutine(Delay());
            _iswaiting = true;
        }
    }
    
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(60);
        panel.SetActive(false);
        _iswaiting = false;
    }
}