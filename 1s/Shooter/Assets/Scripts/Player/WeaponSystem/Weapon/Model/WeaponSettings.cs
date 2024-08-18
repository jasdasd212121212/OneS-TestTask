using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Game design/Player/Weapon")]
public class WeaponSettings : ScriptableObject
{
    [SerializeField][Min(0.0001f)] private float _fireDelay = 1f;
    [SerializeField][Min(1)] private int _damage = 1;
    [SerializeField][Min(0.001f)] private float _bulletSpeed = 10f;

    public float FireDelay => _fireDelay;
    public int Damage => _damage;
    public float BulletSpeed => _bulletSpeed;
}