using AYellowpaper.SerializedCollections;
using DG.Tweening;
using System.Linq;
using UnityEngine;

public class ShopPanelHandler : MonoBehaviour
{
    [SerializeField]
    private SerializedDictionary<SpecialButton, RectTransform> _shopPanels;
    private SpecialButton _currentButton;

    private bool _isOpen;

    private void Start()
    {
        BuildingManager.Instance.GridDragging.OnDragStop += DeactivateGrid;
        BuildingManager.Instance.GridDragging.OnDragStart += DisableShopOpener;
    }

    private void DisableShopOpener()
    {
        _currentButton.interactable = false;
    }

    public void ShopOpener(RectTransform buttonRect)
    {
        _currentButton = _shopPanels.First(elt => elt.Key.gameObject == buttonRect.gameObject).Key; // The button needs to be referenced in the dictionary (field in '---UI---' object).
        if (_currentButton == null) return;

        _isOpen = !_isOpen;
        float height = _isOpen ? _shopPanels[_currentButton].rect.height : 0 ;

        _currentButton.transform.SetAsLastSibling(); // Brings the button to the front of the canvas.
        buttonRect.DOAnchorPosY(height, 0.25f).SetEase(Ease.InOutSine);

        DeactivateGrid();
    }

    private void DeactivateGrid()
    {
        _shopPanels.Where(_shopPanels => _shopPanels.Key != _currentButton).ToList().ForEach(panel => panel.Key.interactable = !_isOpen);
        _currentButton.interactable = true;
        BuildingManager.Instance.GridConstructor.ActivateGrid(_isOpen);
    }
}
