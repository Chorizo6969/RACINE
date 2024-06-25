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
        if (index == 0 && !GetComponent<Expédition>().Ia.GetComponent<HideNSeek>().IsHiding)
        {
            imagevalidate.SetActive(true);
            index++;
        }
        else if (index == 1)
        {
            imagevalidate.SetActive(false);
            index = 0;
        }


        if (GetComponent<Expédition>().Ia.GetComponent<HideNSeek>().IsHiding)
        {
            Jkh.Instance.JeVeuxJouerLaisseMoiAllerJOUEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEER.SetActive(true);
        }
    }

    public void Work()
    {
        youCanWork = false;
        ButtonOfHumanInExpedition.Clear();
        HumanInExpedition.Clear();
        foreach (GameObject obj in List.list)
        {
            if (obj.GetComponent<ChangeColor>().index == 1 && !obj.GetComponent<Expédition>().Ia.GetComponent<HideNSeek>().IsHiding)
            {
                ButtonOfHumanInExpedition.Add(obj);
                HumanInExpedition.Add(obj.GetComponent<Expédition>().Ia);
                obj.GetComponent<Expédition>().Ia.GetComponent<IA>().GiveTarget();
                youCanWork = true;
            }
            else if (obj.GetComponent<Expédition>().Ia.GetComponent<HideNSeek>().IsHiding && obj.GetComponent<ChangeColor>().index == 1)
            {
                obj.GetComponent<ChangeColor>().Change();
            }
        }
        if (youCanWork && id == 1 && HumanInExpedition.Count > 0)
        {
            ExpeditionLoot.instance.WorkingWood();
            Slider.SetActive(true);
        }
        else if (youCanWork && id == 2 && HumanInExpedition.Count > 0)
        {
            ExpeditionLoot.instance.WorkingStone();
            Slider.SetActive(true);
        }
        else if (youCanWork && id == 3 && HumanInExpedition.Count > 0)
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