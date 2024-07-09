using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class SuccesManager : MonoBehaviour
{
    [SerializeField]
    private List<string> _titre;

    [SerializeField]
    private List<string> _description;

    [SerializeField]
    private List<Sprite> _newSprite;

    [SerializeField]
    private Image _sourceImage;

    [SerializeField]
    private TextMeshProUGUI _currentTitre;

    [SerializeField]
    private TextMeshProUGUI _currentDescription;

    [SerializeField]
    private Animation _anim;

    private bool _isPlaying = false;

    public static SuccesManager instance;

    private void Awake()
    {
        instance = this;
    }

    public async void LevelupRacine(int levelracine)
    {
        while (_isPlaying) await Task.Yield();
        if (levelracine == 2)
        {
            _currentTitre.text = _titre[0];
            _currentDescription.text = _description[0];
            _sourceImage.sprite = _newSprite[0];
            StartCoroutine(Delay());
        }
        else if (levelracine == 3)
        {
            _currentTitre.text = _titre[1];
            _currentDescription.text = _description[1];
            _sourceImage.sprite = _newSprite[1];
            StartCoroutine(Delay());
        }
    }

    public async void NombreExpedition()
    {
        while (_isPlaying) await Task.Yield();
        if (Compteur.instance.nombreExpedition == 1)
        {
            _currentTitre.text = _titre[5];
            _currentDescription.text = _description[5];
            _sourceImage.sprite = _newSprite[5];
            StartCoroutine(Delay());
        }
        else if (Compteur.instance.nombreExpedition == 10)
        {
            _currentTitre.text = _titre[6];
            _currentDescription.text = _description[6];
            _sourceImage.sprite = _newSprite[6];
            StartCoroutine(Delay());
        }
        else if (Compteur.instance.nombreExpedition == 30)
        {
            _currentTitre.text = _titre[7];
            _currentDescription.text = _description[7];
            _sourceImage.sprite = _newSprite[7];
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        _anim.Play();
        _isPlaying = true;
        yield return new WaitForSeconds(4.3f);
        _isPlaying = false;
    }
}
