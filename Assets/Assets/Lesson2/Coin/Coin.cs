using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int value = 1;

    public int Value => value;

    private void OnTriggerEnter(Collider other)
    {
        CoinCollector collector = other.GetComponent<CoinCollector>();
        if (collector != null)
        {
            collector.Collect(this);
        }
    }
}
