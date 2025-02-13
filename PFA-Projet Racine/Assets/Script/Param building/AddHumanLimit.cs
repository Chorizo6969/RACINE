using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHumanLimit : MonoBehaviour
{
    [SerializeField] int id;
    [SerializeField] int stock;

    void Start()
    {
        StartCoroutine(Test());
    }

    public void Good()
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

    IEnumerator Test()
    {
        if (id == 2) { yield return new WaitForSeconds(30); }
        yield return new WaitForSeconds(60);
        Good();
    }
}
