using UnityEngine;

public class SickHuman : MonoBehaviour
{
    [SerializeField][Range(0, 1)] private float _sickProba;
    [SerializeField][Range(0, 1)] private float _fakeSickProba;

    public static SickHuman Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void SickProba(ref bool IsSick, ref bool FakeSick, float ProbaFakeSick)
    {
        ProbaFakeSick += _fakeSickProba;
        float random = Random.Range(0f, 1f);
        if (random <= _sickProba)
        {
            IsSick = true;
            return;
        }
        if (random <= ProbaFakeSick)
        {
            FakeSick = true;
            return;
        }

    }
}
