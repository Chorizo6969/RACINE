using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script qui fait évoluer le cercle du timer
/// </summary>
public class Fill : MonoBehaviour
{
    /// <summary>
    /// Référence vers l'image à faire évoluer
    /// </summary>
    [SerializeField] private Image _imageSprite;

    /// <summary>
    /// vitesse de remplissage de l'image
    /// </summary>
    [field : SerializeField] public float FillSpeed { get; set; }

    /// <summary>
    /// Booléen qui renvoie l'état de remplissage de l'image
    /// </summary>
    [field : SerializeField] public bool IsFillAmountFull { get; private set; }

    public GameObject BWARG;

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
            if (BWARG != null)
            {
                BWARG.GetComponent<PTNCOMMENTJLEEZLESYSTEMDEBUILD>().JugementDernier();
            }
        }
        else
        {
            IsFillAmountFull = false;
        }

        //Debug.Log(_imageSprite.fillAmount);
    }
}