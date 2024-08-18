using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private BaseHealth _health;

    [Space]

    [SerializeField] private Image _fillImage;
    [SerializeField] private TextMeshProUGUI _healthText;

    private void Awake()
    {
        _health.healthChanged += OnHealthChanged;
    }

    private void Start()
    {
        OnHealthChanged(_health.CurrentHealth);
    }

    private void OnDestroy()
    {
        _health.healthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int health)
    {
        _fillImage.fillAmount = (float)((float)health / (float)_health.MaxHealth);
        _healthText.text = health.ToString();   
    }
}