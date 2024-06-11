using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    [SerializeField]
    private int id = 0;

    public Listexpedition List;
    public Expédition expédition;
    public List<GameObject> ButtonOfHumanInExpedition;
    public List<GameObject> HumanInExpedition;

    private int index = 0;
    public bool youCanWork;

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
                Debug.Log("1");
                ButtonOfHumanInExpedition.Add(obj);
                HumanInExpedition.Add(obj.GetComponent<Expédition>().Ia);
                obj.GetComponent<Expédition>().Ia.GetComponent<IA>().GiveTarget();
                youCanWork = true;
            }
        }
        if (youCanWork && id == 1)
        {
            ExpeditionLoot.instance.WorkingWood();
        }
        else if (youCanWork && id == 2)
        {
            ExpeditionLoot.instance.WorkingStone();
        }
        else if (youCanWork && id == 3)
        {
            ExpeditionLoot.instance.WorkingWater();
        }
        else
        {
            Debug.Log("0 humain plante connard");
        }
    }
}