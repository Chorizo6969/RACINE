using UnityEngine;
using TMPro;
public class IncrementScore : MonoBehaviour
{
    public TextMeshProUGUI txt_score;
    public int score = 0;
    public int maxStockWood = 200;

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
