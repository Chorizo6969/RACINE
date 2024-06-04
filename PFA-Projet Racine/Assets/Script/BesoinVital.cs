using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BesoinVital : MonoBehaviour
{
    public int id;



    private void OnEnable()
    {
        switch (id)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                Jkh.Instance.OnClickBatimentPanel();
                break;
            case 5:
                Jkh.Instance.OnClickPanelVerif();
                break;
        }
    }

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

            case 4:
                Jkh.Instance.OnClickBatimentPanel();
                break;

            case 5:
                Jkh.Instance.OnClickPanelVerif();
                break;
        }
    }
}