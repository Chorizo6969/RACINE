using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compteur : MonoBehaviour
{
    public int nombreExpedition = 0;
    public int NombreHumanSound = 0;
    public static Compteur instance;

    private void Awake()
    {
        instance = this;
    }
}
