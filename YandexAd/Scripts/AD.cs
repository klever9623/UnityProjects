using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class AD : MonoBehaviour
{
    [SerializeField] private int _money;
    [SerializeField] private Text _moneyText;

    [DllImport("__Internal")]
    private static extern void AddCoinsExternal(int value);

    [DllImport("__Internal")]
    private static extern void ShowAdvExternal();

    private void Start()
    {
        _moneyText.text = "Money: " + _money.ToString();
        ShowAdvExternal();
    }

    public void AddCoins(int value)
    {
        _money += value;
        _moneyText.text = "Money: " + _money.ToString();
    }

    public void AddCoinsShowAd(int value)
    {
        AddCoinsExtern(value);
    }
}
