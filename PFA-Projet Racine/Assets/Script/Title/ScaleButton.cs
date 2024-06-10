using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScaleButton : MonoBehaviour, IPointerEnterHandler,  IPointerExitHandler
{
    [SerializeField]
    private AudioClip _survole;
    [SerializeField]
    private AudioSource _AudioSource;
    private Vector3 _scale;

    private void Start()
    {
        _scale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _AudioSource.clip = _survole;
        _AudioSource.PlayOneShot(_AudioSource.clip);
        transform.DOScale(transform.localScale + new Vector3(0.40f, 0.40f, 0.40f), 0.5f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(_scale, 0.5f);
    }
}
