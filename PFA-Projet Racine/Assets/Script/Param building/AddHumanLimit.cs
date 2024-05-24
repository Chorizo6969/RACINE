using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHumanLimit : MonoBehaviour
{
    [SerializeField] int id;
    [SerializeField] int stock;

    private void Start()
    {
        switch (id)
        {
            case 0:
                IncrementHuman.instance.EditMaxBucheron(stock);
                break;
            case 1:
                IncrementHuman.instance.EditMaxAquaman(stock);
                break;
            case 2:
                IncrementHuman.instance.EditMaxStoneMan(stock);
                break;
        }
    }
}
