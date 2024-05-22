using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class Tweenbatiment : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private GameObject panel;


    public void OnPointerEnter(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(panelOn());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(panelOff());
    }

    IEnumerator panelOn()
    {
        yield return new WaitForSeconds(0.5f);
        panel.SetActive(true);
    }

    IEnumerator panelOff()
    {
        yield return new WaitForSeconds(0.1f);
        panel.SetActive(false);
    }
}
