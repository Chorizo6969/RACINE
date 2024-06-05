using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class DialogueTutoriel : MonoBehaviour
{
    /// <summary>
    /// Mon composant TextMeshPro.
    /// </summary>
    [SerializeField]
    private TMP_Text _text;

    [SerializeField]
    private Image _image;

    /// <summary>
    /// Liste de lignes à afficher séquentiellement.
    /// </summary>
    [SerializeField]
    public List<string> lines;

    /// <summary>
    /// Temps d'attente en secondes après l'affichage d'une lettre normale.
    /// </summary>
    [SerializeField]
    private float _letterDelay;

    /// <summary>
    /// Temps d'attente en secondes (généralement plus long que
    /// <see cref="_letterDelay"/>) après l'affichage d'un symbole de
    /// ponctuation.
    /// </summary>
    [SerializeField]
    private float _punctuationDelay;

    /// <summary>
    /// Index de la ligne à afficher actuellement.
    /// <br/>
    /// On la fait commencer à -1, car <see cref="PrintNextLine"/>
    /// l'incrémente dès le début.
    /// </summary>
    public int _lineIndex = -1;

    public bool _isfinish;

    /// <summary>
    /// Coroutine affichant une ligne.
    /// </summary>
    private Coroutine _printLineCoroutine;

    /// <summary>
    /// Est-ce que le caractère donné en paramètre est un signe de
    /// ponctuation ?
    /// </summary>
    private bool IsPunctuation(char c) => c is '?' or '.' or '!' or ',';

    public static DialogueTutoriel instance;

    public void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        _isfinish = false;
        _text.text = string.Empty;
        _image.gameObject.SetActive(true);
        _lineIndex = -1;
        _printLineCoroutine = StartCoroutine(PrintNextLine());
    }

    private void Update()
    {
        // Dans ce update, on ne veut faire quelque chose que si la touche
        // espace est appuyée. Donc on s'arrête là si elle ne l'est pas.

        // Si vous utilisez l'ancien système d'input de Unity :
        if (!Input.GetKeyDown(KeyCode.Space)) return;

        if (_printLineCoroutine != null)
        {
            StopPrintAndShowAll();
        }
        else
        {
            _printLineCoroutine = StartCoroutine(PrintNextLine());
        }
    }

    private IEnumerator PrintNextLine()
    {
        if (_printLineCoroutine != null) yield break;

        if (_lineIndex >= lines.Count - 1)
        {
            Debug.Log("dialogue fini !");
            gameObject.SetActive(false);
            _image.gameObject.SetActive(false);
            _isfinish = true;
            yield break;
        }


        _lineIndex++;

        string line = lines[_lineIndex];

        _text.maxVisibleCharacters = 0;
        _text.text = line;

        foreach (char character in line)
        {
            _text.maxVisibleCharacters++;
            float delay = IsPunctuation(character)
                ? _punctuationDelay
                : _letterDelay;

            yield return new WaitForSeconds(delay);
        }

        _printLineCoroutine = null;
    }

    private void StopPrintAndShowAll()
    {
        if (_printLineCoroutine == null) return;

        StopCoroutine(_printLineCoroutine);
        _printLineCoroutine = null;
        _text.maxVisibleCharacters = lines[_lineIndex].Length;
    }
}
