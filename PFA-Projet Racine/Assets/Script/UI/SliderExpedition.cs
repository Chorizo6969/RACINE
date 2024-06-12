using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SliderExpedition : MonoBehaviour
{
    [SerializeField]
    private Slider sliderExpedition;
    private float secondes;

    private void FixedUpdate()
    {
        if (secondes <= 60)
        {
            secondes += Time.deltaTime;
            sliderExpedition.value = secondes;
        }
        else
        {
            gameObject.SetActive(false);
            secondes = 0;
        }
    }
}
