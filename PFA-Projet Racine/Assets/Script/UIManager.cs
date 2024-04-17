using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Animator _uiAnimator;

    public void ActivationUi()
    {
        _uiAnimator.SetBool("Click", true);
    }

    public void DesactivationUi()
    {
        _uiAnimator.SetBool("Click", false);
    }
}
