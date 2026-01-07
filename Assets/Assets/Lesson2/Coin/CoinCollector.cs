using UnityEngine;
using System;

public class CoinCollector : MonoBehaviour
{
    public int Coins { get; private set; }

    public event Action<int> OnCoinsChanged;

    public void Collect(Coin coin)
    {
        Coins += coin.Value;
        OnCoinsChanged?.Invoke(Coins);
        Destroy(coin.gameObject);
    }
}
