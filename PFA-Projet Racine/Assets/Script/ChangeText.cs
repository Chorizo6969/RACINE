using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeText : MonoBehaviour
{
    public static ChangeText instance;

    private void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// change le composant texte d'un text mesh pro
    /// </summary>
    /// <param name="text">nouvelle variable text à appliquer</param>
    /// <param name="textMeshPro">Object text mesh pro à modifier</param>
    public void ChangeTextFunc(string text, TextMeshProUGUI textMeshPro)
    {
        textMeshPro.text = text;
    }
}