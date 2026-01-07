using UnityEngine;
using System.Collections;

public class Thorn : MonoBehaviour
{
    [SerializeField] private float damage = 10f;
    [SerializeField] private float poisonDamage = 1f;
    [SerializeField] private float poisonDuration = 30f;
    [SerializeField] private float poisonTick = 3f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<HealthSystem>(out var health))
        {
            health.TakeDamage(damage);
            StartCoroutine(
                ApplyPoison(health, poisonDamage, poisonDuration, poisonTick)
            );
        }
    }

    public IEnumerator ApplyPoison(HealthSystem target, float damagePerTick, float duration, float tickRate)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            target.TakeDamage(damagePerTick);
            yield return new WaitForSeconds(tickRate);
            elapsed += tickRate;
        }
    }
}