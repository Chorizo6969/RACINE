using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jkh : MonoBehaviour
{
    public bool OriginalBooliste;

    public bool boolisteBuildingPanel;
    public bool BOOLISTEBUILDINGPANEL;

    public bool boolisteOptionPanel;
    public bool BOOLISTEOPTIONPANEL;

    public bool boolisteExpedBoisPanel;
    public bool BOOLISTEEXPEDBOISPANEL;

    public bool boolisteExpedEauPanel;
    public bool BOOLISTEEXPEDEAUPANEL;

    public bool boolisteExpedPierrePanel;
    public bool BOOLISTEEXPEDPIERREPANEL;

    public static Jkh Instance;

    private void Awake()
    {
        Instance = this;
    }
    public void OnClickBuildingPanel()
    {
        boolisteBuildingPanel = true;
        if (boolisteBuildingPanel && !BOOLISTEBUILDINGPANEL)
        {
            boolisteBuildingPanel = false;
            BOOLISTEBUILDINGPANEL = true;
        }
        else if (boolisteBuildingPanel && BOOLISTEBUILDINGPANEL)
        {
            boolisteBuildingPanel = false;
            BOOLISTEBUILDINGPANEL = false;
        }
    }

    public void OnClickOptionPanel()
    {
        boolisteOptionPanel = true;
        if (boolisteOptionPanel && !BOOLISTEOPTIONPANEL)
        {
            boolisteOptionPanel = false;
            BOOLISTEOPTIONPANEL = true;
        }
        else if (boolisteOptionPanel && BOOLISTEOPTIONPANEL)
        {
            boolisteOptionPanel = false;
            BOOLISTEOPTIONPANEL = false;
        }
    }

    public void OnClickExpedBoisPanel()
    {
        boolisteExpedBoisPanel = true;
        if (boolisteExpedBoisPanel && !BOOLISTEEXPEDBOISPANEL)
        {
            boolisteExpedBoisPanel = false;
            BOOLISTEEXPEDBOISPANEL = true;
        }
        else if (boolisteExpedBoisPanel && BOOLISTEEXPEDBOISPANEL)
        {
            boolisteExpedBoisPanel = false;
            BOOLISTEEXPEDBOISPANEL = false;
        }
    }

    public void OnClickExpedEauPanel()
    {
        boolisteExpedEauPanel = true;
        if (boolisteExpedEauPanel && !BOOLISTEEXPEDEAUPANEL)
        {
            boolisteExpedEauPanel = false;
            BOOLISTEEXPEDEAUPANEL = true;
        }
        else if (boolisteExpedEauPanel && BOOLISTEEXPEDEAUPANEL)
        {
            boolisteExpedEauPanel = false;
            BOOLISTEEXPEDEAUPANEL = false;
        }
    }

    public void OnClickExpedPierrePanel()
    {
        boolisteExpedPierrePanel = true;
        if (boolisteExpedPierrePanel && !BOOLISTEEXPEDEAUPANEL)
        {
            boolisteExpedPierrePanel = false;
            BOOLISTEEXPEDEAUPANEL = true;
        }
        else if (boolisteExpedPierrePanel && BOOLISTEEXPEDEAUPANEL)
        {
            boolisteExpedPierrePanel = false;
            BOOLISTEEXPEDEAUPANEL = false;
        }
    }

    /*public void OnClickExpedPierrePanel()
    {
        boolisteExpedPierrePanel = true;
        if (boolisteExpedPierrePanel && !BOOLISTEEXPEDEAUPANEL)
        {
            boolisteExpedPierrePanel = false;
            BOOLISTEEXPEDEAUPANEL = true;
        }
        else if (boolisteExpedPierrePanel && BOOLISTEEXPEDEAUPANEL)
        {
            boolisteExpedPierrePanel = false;
            BOOLISTEEXPEDEAUPANEL = false;
        }
    }*/

    public bool CheckAllBool()
    {
        OriginalBooliste = boolisteBuildingPanel && boolisteOptionPanel && boolisteExpedBoisPanel && boolisteExpedEauPanel && boolisteExpedPierrePanel;
        return OriginalBooliste;
    }
}