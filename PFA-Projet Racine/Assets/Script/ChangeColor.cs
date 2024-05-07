using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    private int index = 0;
    public Listexpedition List;
    public Expédition expédition;

    public void Change()
    {
        if (index == 0)
        {
            Image button_image = GetComponent<Image>();
            button_image.color = Color.red;
            index++;
        }
        else if (index == 1)
        {
            Image button_image = GetComponent<Image>();
            button_image.color = Color.white;
            index = 0;
        }
    }

    public void Work()
    {
        Image button_image = GetComponent<Image>();
        Debug.Log("Grosse pute");
        foreach (GameObject obj in List.list)
        {
            Debug.Log("petite pute");
            if (obj.GetComponent<ChangeColor>().index == 1)
            {
                obj.GetComponent<Expédition>().Ia.GetComponent<IA>().GiveTarget();
                Debug.Log("ohoh cheh");
            }
        }
    }
}
