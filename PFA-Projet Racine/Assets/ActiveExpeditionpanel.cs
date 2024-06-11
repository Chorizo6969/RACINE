using System.Collections;
using UnityEngine;

public class ActiveExpeditionpanel : MonoBehaviour
{
    [SerializeField]
    private GameObject panel;
    private bool _iswaiting;

    public void DesactivationPanel()
    {
        if (Jkh.Instance.BOOLISTEBATIMENTPANEL)
        {
            panel.SetActive(true);
        }
        if (!_iswaiting)
        {
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
