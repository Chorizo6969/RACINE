using TMPro;
using UnityEngine;

/// <summary>
/// Script qui permet d'incrémenter le score de bois.
/// </summary>
public class IncrementScore : MonoBehaviour
{
    /// <summary>
    /// Lien vers le texte qui affiche le score
    /// </summary>
    [SerializeField]
    private TextMeshProUGUI txt_score;

    /// <summary>
    /// Variable int qui simule le score de bois
    /// </summary>
    private int score = 0;

    /// <summary>
    /// Variable int qui indique le stockage maximun de bois
    /// </summary>
    private int maxStockWood = 200;

    /// <summary>
    /// Fonction qui modifie et incrémente le score en temps réel.
    /// </summary>
    public void Increment_score()
    {
        if (score < maxStockWood)
        {
            score++;
            if (score > maxStockWood)
            {
                score = maxStockWood;
            }
            txt_score.text = score.ToString();
        }
        else
        {
            Debug.Log("Stockage full");
        }
    }
}
