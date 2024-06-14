using TMPro;
using UnityEngine;

public class IncrementHuman : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _textHuman;

    [SerializeField] private TextMeshProUGUI _textMaxHuman;

    public int _count = 0;
    public int _maxHuman = 0;

    public int _countBucheron;
    public int _maxBucheron;
    public TextMeshProUGUI BucheronText;
    public TextMeshProUGUI MaxBucheronText;

    public int _countAquaman;
    public int _maxAquaman;
    public TextMeshProUGUI AquamanText;
    public TextMeshProUGUI MaxAquamanText;

    public int _countStoneMan;
    public int _maxStoneMan;
    public TextMeshProUGUI StoneManText;
    public TextMeshProUGUI MaxStoneManText;

    public static IncrementHuman instance;

    public void Awake()
    {
        instance = this;
        EditMaxHuman(0);
    }

    private void Start()
    {
        BucheronText.text = _countBucheron.ToString();
        MaxBucheronText.text = _maxBucheron.ToString();
        AquamanText.text = _countAquaman.ToString();
        MaxAquamanText.text = _maxAquaman.ToString();
        StoneManText.text = _countStoneMan.ToString();
        MaxStoneManText.text = _maxStoneMan.ToString();
    }

    public void Stonks()
    {
        _count++;
        _textHuman.text = _count.ToString();
    }

    public void Death(int death)
    {
        _count -= death;
        _textHuman.text = _count.ToString();
    }

    public void EditMaxHuman(int amount)
    {
        _maxHuman += amount;
        _textMaxHuman.text = _maxHuman.ToString();
    }

    public void EditBucheron(int amount)
    {
        _countBucheron += amount;
        BucheronText.text = _countBucheron.ToString();
        TutoHuman.Instance.WarningTuto();
    }
    
    public void EditMaxBucheron(int amount)
    {
        _maxBucheron += amount;
        MaxBucheronText.text = _maxBucheron.ToString();
        TutoHuman.Instance.WarningTuto();
    }

    public void EditAquaman(int amount)
    {
        _countAquaman += amount;
        AquamanText.text = _countAquaman.ToString();
        TutoHuman.Instance.WarningTuto();
    }
    
    public void EditMaxAquaman(int amount)
    {
        _maxAquaman += amount;
        MaxAquamanText.text = _maxAquaman.ToString();
    }

    public void EditStoneMan(int amount)
    {
        _countStoneMan += amount;
        StoneManText.text = _countStoneMan.ToString();
    }
    
    public void EditMaxStoneMan(int amount)
    {
        _maxStoneMan += amount;
        MaxStoneManText.text = _maxStoneMan.ToString();
    }
}