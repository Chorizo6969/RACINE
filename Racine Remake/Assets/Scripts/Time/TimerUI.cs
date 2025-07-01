using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] TextMeshProUGUI _hourTxt;
    [SerializeField] private RectTransform _clockImage;

    public void UpdateClockRotation()
    {
        float totalMinutes = TimeInGame.Instance.Hours * 60 + TimeInGame.Instance.Minutes;
        float rotationZ = -((totalMinutes / 1440f) * 360f); // 1440 = minutes dans une journée
        _clockImage.rotation = Quaternion.Euler(180, 0, rotationZ);
    }

    public void SpeedTime() //Bouton
    {
        if (TimeInGame.Instance.TimeSpeed == 2) { TimeInGame.Instance.TimeSpeed = 8; }
        else { TimeInGame.Instance.TimeSpeed = 2; }
    }

    public void ChangeUIHours(string newHours) { _hourTxt.text = newHours; }
}
