using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class BaseHealth : MonoBehaviour, IDamageble
{
    [SerializeField] private HealthSettings _settings;

    private int _health;

    public int MaxHealth => _settings.MaxHealth;
    public int CurrentHealth => _health;

    public event Action<int> healthChanged;
    public event Action dead;

    private void Awake()
    {
        _health = _settings.MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (damage <= 0)
        {
            Debug.LogError($"Error -> can`t TakeDamage with damage = {damage}");
            return;
        }

        _health -= damage;

        if (_health <= 0)
        {
            Die();
            _health = 0;
        }

        healthChanged?.Invoke(_health);
    }

    private void Die()
    {
        dead?.Invoke();
        OnDead();
    }

    protected virtual void OnDead() { }
}