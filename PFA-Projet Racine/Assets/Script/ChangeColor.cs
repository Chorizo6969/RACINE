using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    [SerializeField]
    private int id = 0;
    public GameObject imagevalidate;
    public Listexpedition List;
    public Expédition expédition;
    public List<GameObject> ButtonOfHumanInExpedition;
    public List<GameObject> HumanInExpedition;
    public GameObject Slider;
    private int index = 0;
    public bool youCanWork;

    public void Change()
    {
        if (index == 0)
        {
            imagevalidate.SetActive(true);
            index++;
        }
        else if (index == 1)
        {
            imagevalidate.SetActive(false);
            index = 0;
        }
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
                youCanWork = true;
            }
        }
        if (youCanWork && id == 1)
        {
            ExpeditionLoot.instance.WorkingWood();
            Slider.SetActive(true);
        }
        else if (youCanWork && id == 2)
        {
            ExpeditionLoot.instance.WorkingStone();
            Slider.SetActive(true);
        }
        else if (youCanWork && id == 3)
        {
            ExpeditionLoot.instance.WorkingWater();
            Slider.SetActive(true);
        }
        else
        {
            Debug.Log("0 humain plante");
        }
    }
}