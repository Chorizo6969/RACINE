using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimButton : MonoBehaviour
{

    [SerializeField] private AnimationClip _anim1;
    [SerializeField] private AnimationClip _anim2;
    [SerializeField] private Animation _animCompo;
    [SerializeField] private Button _button;
    private bool _open = true;

    public async void Clic()
    {
        if(_open)
        {
            _button.interactable = false;
            _animCompo.clip = _anim1;
            _animCompo.Play();
            _open = false;
            await Task.Delay(250);
            _button.interactable = true;
        }
        else
        {
            _button.interactable = false;
            _animCompo.clip = _anim2;
            _animCompo.Play();
            _open = true;
            await Task.Delay(250);
            _button.interactable = true;
        }
    }
}
