using DG.Tweening;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ShopApparitionHandler : MonoBehaviour
{
    [SerializeField]
    private RectTransform _shopPanel;
    [SerializeField]
    private Tilemap _mainTilemap;
    private RectTransform _shop;
    private bool _opened;

    private void Awake()
    {
        _shop = GetComponent<RectTransform>();
    }

    public void ShopApparition()
    {
        _opened = !_opened;

        _mainTilemap.gameObject.SetActive(_opened);
        _shop.DOAnchorPosY(_opened ? _shopPanel.rect.height : 0, 0.25f).SetEase(Ease.InOutSine);
    }
}
