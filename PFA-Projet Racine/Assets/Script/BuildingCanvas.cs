using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCanvas : MonoBehaviour
{
    [SerializeField] private GameObject CanvasOptionPanel;

    public void PanelSetActive(bool enabled)
    {
        CanvasOptionPanel.SetActive(enabled);
    }
}