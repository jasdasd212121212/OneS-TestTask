using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using System.Linq;
using Random = UnityEngine.Random;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private EnemyFactorySettings _settings;

    [Space]

    [SerializeField] private EnemyMover _enemy;
    [SerializeField] private Transform[] _spawnPoint;

    [Space]

    [SerializeField][Min(3)] private int _enemyPoolSize = 20;

    private GameObjectMonoPool<EnemyMover> _enemyPool;

    private int _killEnemyesToWin;
    private int _currentKilledEnemyes;

    public event Action win;

    public Transform[] SpawnedEnemyes => _enemyPool.BusyPool.Select(enemy => enemy.CachedTransform).ToArray();
    private Transform SpawnPoint => _spawnPoint[Random.Range(0, _spawnPoint.Length)];

    private void Start()
    {
        _enemyPool = new GameObjectMonoPool<EnemyMover>(_enemy, transform, _enemyPoolSize);
        _killEnemyesToWin = _settings.EnemyToWin;

        SpawnLoop().Forget();
    }

    public void DespawnEnemy(EnemyMover enemy, bool doIncreaseKillCount)
    {
        if (doIncreaseKillCount)
        {
            _currentKilledEnemyes++;
        }

        _enemyPool.ForceReturnToPool(enemy);
    }

    private void Spawn()
    {
        EnemyMover mover = _enemyPool.Pop();

        mover.CachedTransform.SetParent(null);
        mover.CachedTransform.position = SpawnPoint.position;
    }

    private async UniTask SpawnLoop()
    {
        while (_currentKilledEnemyes < _killEnemyesToWin)
        {
            Spawn();
            await UniTask.Delay(TimeSpan.FromSeconds(_settings.TimeToSpawn));
        }

        win?.Invoke();
    }
}