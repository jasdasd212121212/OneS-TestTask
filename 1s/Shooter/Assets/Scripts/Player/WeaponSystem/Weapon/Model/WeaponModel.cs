using System;
using UnityEngine;

public class WeaponModel : MonoBehaviour, IWeapon
{
    [SerializeField] private Transform _fireOrigin;
    [SerializeField] protected Bullet _bulletPrefab;

    [Space]

    [SerializeField] private WeaponSettings _settings;

    private float _nextShotTime;
    private bool _isShooting;

    private MonoFactory<Bullet> _bulletFactory;

    public event Action shoted;

    private void Awake()
    {
        _bulletFactory = new MonoFactory<Bullet>(_bulletPrefab);
    }

    public void StartShooting()
    {
        _isShooting = true;
    }

    public void StopShooting()
    {
        _isShooting = false;
    }

    private void Update()
    {
        if (_isShooting)
        {
            if (Time.time >= _nextShotTime)
            {
                Shot();
                _nextShotTime = Time.time + _settings.FireDelay;
            }
        }
    }

    protected void Shot()
    {
        _bulletFactory.Create(_fireOrigin.position, _fireOrigin.rotation).Launch(_settings.Damage, _settings.BulletSpeed);
        shoted?.Invoke();
    }
}