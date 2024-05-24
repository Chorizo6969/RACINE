using TMPro;
using UnityEngine;

public class IncrementHuman : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _textHuman;

    [SerializeField] private TextMeshProUGUI _textMaxHuman;

    private int _count = 0;
    [SerializeField] private int _maxHuman = 0;

    public int _countBucheron;
    public int _maxBucheron;

    public int _countAquaman;
    public int _maxAquaman;

    public int _countStoneMan;
    public int _maxStoneMan;

    public static IncrementHuman instance;

    public void Awake()
    {
        instance = this;
        EditMaxHuman(0);
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
    }
    
    public void EditMaxBucheron(int amount)
    {
        _maxBucheron += amount;
    }

    public void EditAquaman(int amount)
    {
        _countAquaman += amount;
    }
    
    public void EditMaxAquaman(int amount)
    {
        _maxAquaman += amount;
    }

    public void EditStoneMan(int amount)
    {
        _countStoneMan += amount;
    }
    
    public void EditMaxStoneMan(int amount)
    {
        _maxStoneMan += amount;
    }
}