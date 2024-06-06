using System;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

/// <summary>
/// Script qui donne une graine à la souris
/// </summary>
public class GivePlant : MonoBehaviour
{
    /// <summary>
    /// Référence de la graine qui va être donné
    /// </summary>
    [SerializeField] private GameObject _seed;

    public Texture2D _seedTexture;
    public Modifcursor _modifcursor;

    /// <summary>
    /// référence de la caméra
    /// </summary>
    [SerializeField] private GameObject _camera;

    [SerializeField] private GameObject _humanPlantPrefab;

    [SerializeField] private GameObject _buttonExpeditionPrefabBuche;
    [SerializeField] private GameObject _buttonExpeditionPrefabAquaman;
    [SerializeField] private GameObject _buttonExpeditionPrefabMineur;

    [SerializeField] private GameObject _content;

    public int _nombreGraines;

    /// <summary>
    /// attribue la graine définie à l'emplacement de graine de al caméra
    /// </summary>
    public void OnClick()
    {
        if (_nombreGraines > 0)
        {
            ClickFieldManager _clickFieldManager = _camera.GetComponent<ClickFieldManager>();
            _clickFieldManager.HumanSeed = _seed;
            GiveRefToField.instance.GiveRefPasTuple(_clickFieldManager.gameObject, _humanPlantPrefab, _buttonExpeditionPrefabBuche, _buttonExpeditionPrefabAquaman, _buttonExpeditionPrefabMineur, _content);
            _modifcursor.ChangeCursor(_seedTexture);
            _nombreGraines --;
        }
        else
        {
            Debug.Log("Pas de graines...");
        }

    }
}