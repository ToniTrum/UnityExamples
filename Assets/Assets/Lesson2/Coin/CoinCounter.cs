using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] private CoinCollector collector;
    [SerializeField] private TMP_Text coinText;

    private void Start()
    {
        collector.OnCoinsChanged += UpdateText;
        UpdateText(collector.Coins);
    }

    private void UpdateText(int value)
    {
        coinText.text = $"Coins: {value}";
    }
}
