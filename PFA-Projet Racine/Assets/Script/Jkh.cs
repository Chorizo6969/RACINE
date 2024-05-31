using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jkh : MonoBehaviour
{
    public bool booliste;
    public bool BOOLISTE;

    public static Jkh Instance;

    private void Awake()
    {
        Instance = this;
    }
    public void OnClick()
    {
        booliste = true;
        if (booliste && !BOOLISTE)
        {
            booliste = false;
            BOOLISTE = true;
        }
        else if (booliste && BOOLISTE)
        {
            booliste = false;
            BOOLISTE = false;
        }
    }
}
