using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    private int index = 0;
    public Listexpedition List;
    public Expédition expédition;
    public List<GameObject> ButtonOfHumanInExpedition;
    public List<GameObject> HumanInExpedition;

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

    public void Désactive() // il faut qu'il change le prefab ptn
    {
        Image button_image = GetComponent<Image>();
        button_image.color = Color.white;
    }

    public void Work()
    {
        ButtonOfHumanInExpedition.Clear();
        HumanInExpedition.Clear();
        foreach (GameObject obj in List.list)
        {
            if (obj.GetComponent<ChangeColor>().index == 1)
            {
                ButtonOfHumanInExpedition.Add(obj);
                HumanInExpedition.Add(obj.GetComponent<Expédition>().Ia);
                obj.GetComponent<Expédition>().Ia.GetComponent<IA>().GiveTarget();
            }
        }
    }
}