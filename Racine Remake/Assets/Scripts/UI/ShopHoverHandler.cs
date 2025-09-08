using DG.Tweening;
using UnityEngine;

public class ShopHoverHandler : MonoBehaviour
{
    public void OnHover(RectTransform button)
    {
        button.DOScaleY(1.1f, 0.25f).SetEase(Ease.InOutSine);
    }

    public void OnDeselect(RectTransform button)
    {
        button.DOScaleY(1f, 0.25f).SetEase(Ease.InOutSine);
    }
}
