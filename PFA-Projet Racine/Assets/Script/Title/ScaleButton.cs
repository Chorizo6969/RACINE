using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScaleButton : MonoBehaviour, IPointerEnterHandler,  IPointerExitHandler
{
    private Vector3 _scale;

    private void Start()
    {
        _scale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(transform.localScale + new Vector3(0.40f, 0.40f, 0.40f), 0.5f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(_scale, 0.5f);
    }
}
