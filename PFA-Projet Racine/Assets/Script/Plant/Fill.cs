using UnityEngine;
using UnityEngine.UI;

public class Fill : MonoBehaviour
{
    [SerializeField] private Image _imageSprite;
    [field : SerializeField] public float FillSpeed { get; set; }
    [field : SerializeField] public bool IsFillAmountFull { get; private set; }

    private void OnEnable()
    {
        _imageSprite.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _imageSprite.fillAmount += FillSpeed * Time.deltaTime;
        if (_imageSprite.fillAmount == 1)
        {
            IsFillAmountFull = true;
        }
        else
        {
            IsFillAmountFull = false;
        }
    }
}