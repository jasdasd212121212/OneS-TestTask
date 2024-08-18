using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

public class PlayerAutoAttacker : MonoBehaviour
{
    [SerializeField] private WeaponRotater _rotater;
    [SerializeField] private PlayerWeaponEquipment _player;

    [Space]

    [SerializeField] private PlayerAutoAttackerSettings _settings;

    [Inject] private EnemyFactory _enemyFactory;

    private Transform _cachedTransform;
    private Transform[] _enemyesList;

    private const float ENEMY_LIST_UPDATE_DELAY = 0.2f;

    private void Start()
    {
        _cachedTransform = transform;
        EnemyListUpdateLoop().Forget();
    }

    private void FixedUpdate()
    {
        Transform nearestEnemy = FindNearestEnemy(out float distance);

        if (nearestEnemy != null && distance <= _settings.AttackRadius)
        {
            _player.CurrentWeapon.StartShooting();
            _rotater.SetTarget(nearestEnemy);
        }
        else
        {
            _player.CurrentWeapon.StopShooting();
            _rotater.SetTarget(null);
        }
    }

    private Transform FindNearestEnemy(out float distanceToEnemy)
    {
        float currentDisatnce = float.MaxValue;
        int nearesEnemyIndex = 0;

        if (_enemyesList == null || _enemyesList.Length == 0)
        {
            distanceToEnemy = currentDisatnce;
            return null;
        }

        try
        {
            for (int i = 0; i < _enemyesList.Length; i++)
            {
                float distance = Vector3.Distance(_enemyesList[i].position, _cachedTransform.position);

                if (distance < currentDisatnce && _enemyesList[i].gameObject.activeInHierarchy == true)
                {
                    currentDisatnce = distance;
                    nearesEnemyIndex = i;
                }
            }

            distanceToEnemy = currentDisatnce;
            return _enemyesList[nearesEnemyIndex];
        }
        catch
        {
            distanceToEnemy = currentDisatnce;
            return null;
        }
    }

    private async UniTask EnemyListUpdateLoop()
    {
        while (true)
        {
            try
            {
                _enemyesList = _enemyFactory.SpawnedEnemyes;
            }
            catch { }
            
            await UniTask.WaitForSeconds(ENEMY_LIST_UPDATE_DELAY);
        }
    }
}