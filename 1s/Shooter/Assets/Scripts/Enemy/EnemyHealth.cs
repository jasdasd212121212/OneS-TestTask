using UnityEngine;
using Zenject;

[RequireComponent(typeof(EnemyMover))]
public class EnemyHealth : BaseHealth
{
    [Inject] private EnemyFactory _spawner;

    protected override void OnDead()
    {
        _spawner.DespawnEnemy(GetComponent<EnemyMover>(), true);
    }
}