using DG.Tweening;
using UnityEngine;

public class ShopPanelHandler : MonoBehaviour
{
    [SerializeField]
    private RectTransform _shopPanel;
    [SerializeField]
    private RectTransform _shopContainer;
    private bool _isOpen;
    [SerializeField]
    private SpecialButton _shopButton;

    private void Start()
    {
        BuildingManager.Instance.GridDragging.OnDragStop += DeactivateGrid;
        BuildingManager.Instance.GridDragging.OnDragStart += DisableShopOpener;
    }

    private void DisableShopOpener()
    {
        _shopButton.interactable = false;
    }

    public void ShopOpener()
    {
        _isOpen = !_isOpen;
        float height = _isOpen ? 0 : -_shopPanel.rect.height;
        _shopContainer.DOAnchorPosY(height, 0.25f).SetEase(Ease.InOutSine);
        DeactivateGrid();
    }

    private void DeactivateGrid()
    {
        _shopButton.interactable = true;
        BuildingManager.Instance.GridConstructor.ActivateGrid(_isOpen);
    }
}
