using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BesoinVital : MonoBehaviour
{
    public int id;
    private void OnDisable()
    {
        switch (id)
        {
            case 0:
                Jkh.Instance.OnClickOptionPanel();
                break;

            case 1:
                Jkh.Instance.OnClickExpedBoisPanel();
                break;

            case 2:
                Jkh.Instance.OnClickExpedEauPanel();
                break;

            case 3:
                Jkh.Instance.OnClickExpedPierrePanel();
                break;
        }
    }
}