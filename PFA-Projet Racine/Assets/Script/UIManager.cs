using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Animator _uiAnimator;
    [SerializeField]
    private GameObject _panel;
    [SerializeField]
    private Button _button;

    public bool _isOpen;

    private int index = 1;
    public static UIManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void ActivationUi()
    {
        Jkh.Instance.OnClickBuildingPanel();
        if (index == 1)
        {
            _button.interactable = false;
            _isOpen = true;
            _uiAnimator.SetInteger("Click", 1);
            StartCoroutine(Delay());
            index = 2;
        }
        else if (index == 2)
        {
            _button.interactable = false;
            _isOpen = false;
            _uiAnimator.SetInteger("Click", 2);
            StartCoroutine(Delay());
            index = 1;
        }

    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.7f);
        _button.interactable = true;

    }
}
