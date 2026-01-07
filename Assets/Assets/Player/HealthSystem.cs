using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;
    public float CurrentHealth => currentHealth;

    public event Action<float> OnDamaged;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Math.Clamp(currentHealth - damage, 0, maxHealth);
        OnDamaged?.Invoke(CurrentHealth);

        Debug.Log($"{gameObject.name} took {damage} damage. HP: {currentHealth}");
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
