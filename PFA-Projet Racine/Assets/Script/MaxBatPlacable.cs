using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxBatPlacable : MonoBehaviour
{
    public static MaxBatPlacable Instance;

    public int maxBat;
    public int actuBat;

    private void Awake()
    {
        Instance = this;
    }

    public void IncreaseMaxBat(int plusBat)
    {
        maxBat += plusBat;
    }

    public void IncreaseActuBat(int plusActuBat)
    {
        actuBat += plusActuBat;
    }
}
