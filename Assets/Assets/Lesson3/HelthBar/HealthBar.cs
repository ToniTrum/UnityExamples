using UnityEngine;
using TMPro;
using System;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private HealthSystem health;
    [SerializeField] private TMP_Text coinText;

    private void Start()
    {
        health.OnDamaged += UpdateText;
        UpdateText(health.CurrentHealth);
    }

    private void UpdateText(float value)
    {
        coinText.text = $"Health: {value}";
    }
}