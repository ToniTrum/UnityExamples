using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private float spawnChance = 0.3f;
    [SerializeField] private float coinHeight = 0.5f;

    private void Start()
    {
        SpawnCoins();
    }

    private void SpawnCoins()
    {
        foreach (Transform child in transform)
        {
            if (!child.name.Contains("Tile")) continue;

            if (Random.value <= spawnChance)
            {
                Vector3 spawnPos = child.position + Vector3.up * coinHeight;
                Instantiate(coinPrefab, spawnPos, Quaternion.identity, transform);
            }
        }
    }
}
