using UnityEngine;

[CreateAssetMenu(fileName = "EnemySpawnerSettings", menuName = "Game design/Enemy/SpawnerSettings")]
public class EnemyFactorySettings : ScriptableObject
{
    [SerializeField][Min(1)] private int _minEnemyToWin;
    [SerializeField][Min(2)] private int _maxEnemyToWin;

    [Space]

    [SerializeField][Min(0.001f)] private float _minTimeToSpawnEnemy;
    [SerializeField][Min(0.001f)] private float _maxTimeToSpawnEnemy;

    public int EnemyToWin => Random.Range(_minEnemyToWin, _maxEnemyToWin);
    public float TimeToSpawn => Random.Range(_minTimeToSpawnEnemy, _maxTimeToSpawnEnemy);

    private void OnValidate()
    {
        _minEnemyToWin = Mathf.Clamp(_minEnemyToWin, 1, _maxEnemyToWin);
        _minTimeToSpawnEnemy = Mathf.Clamp(_minTimeToSpawnEnemy, 0.001f, _maxTimeToSpawnEnemy);
    }
}