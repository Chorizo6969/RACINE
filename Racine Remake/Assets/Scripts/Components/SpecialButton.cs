using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpecialButton : Button
{

    #region Unity Events

    public UnityEvent OnHoverEvent = new UnityEvent();
    public UnityEvent OnDeselectEvent = new UnityEvent();
    public UnityEvent OnDisabledEvent = new UnityEvent();
    public UnityEvent OnEnabledEvent = new UnityEvent();

    #endregion

    private bool _isInteractable = false;

    [MenuItem("GameObject/UI/Special Button", false, 1)]
    private static void CreateButton()
    {
        Transform canvas = FindFirstObjectByType<Canvas>().transform;
        
        if(canvas == null)
        {
            canvas = new GameObject("Canvas").transform;
            canvas.AddComponent<Canvas>();
            canvas.AddComponent<CanvasScaler>();
            canvas.AddComponent<GraphicRaycaster>();
        }

        GameObject buttonObject = new GameObject("Button");
        GameObject textObject = new GameObject("Text");

        Image image = buttonObject.AddComponent<Image>();
        SpecialButton button = buttonObject.AddComponent<SpecialButton>();

        buttonObject.transform.SetParent(canvas, false);
        textObject.transform.SetParent(buttonObject.transform, false);

        RectTransform rectTransform = buttonObject.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(150, 50);

        TextMeshProUGUI display = textObject.AddComponent<TextMeshProUGUI>();
        display.alignment = TextAlignmentOptions.Center;
        display.color = Color.black;
        display.text = "Button";
    }
    private void Update()
    {
        if (IsInteractable() != _isInteractable)
        {
            OnInteractable(IsInteractable());
            _isInteractable = IsInteractable();
        }
    }

    #region Event Methods

    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);
        OnDeselectEvent.Invoke();
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        OnHoverEvent.Invoke();
    }
    
    public void OnInteractable(bool interactable)
    {
        if(interactable) OnEnabledEvent.Invoke();
        else OnDisabledEvent.Invoke();
    }

    #endregion

    #region Button Additionnal Methods

    public void Print(string log)
    {
        Debug.Log(log);
    }

    #endregion
}
