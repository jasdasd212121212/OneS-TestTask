using UnityEngine;
using Zenject;

[RequireComponent(typeof(Collider2D), typeof(EnemyMover))]
public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private EnemyAttackSettings _settings;

    [Inject] private EnemyFactory _enemyFactory;


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out PlayerHealth player))
        {
            player.TakeDamage(_settings.Damage);
            _enemyFactory.DespawnEnemy(GetComponent<EnemyMover>(), false);
        }
    }
}