using UnityEngine;

[CreateAssetMenu(fileName = "EnemyMoveSettings", menuName = "Game design/Enemy/MoveSettings")]
public class EnemyMoveSettings : ScriptableObject
{
    [SerializeField][Min(0.001f)] private float _minMoveSpeed;
    [SerializeField][Min(0.002f)] private float _maxMoveSpeed;

    public float RandomMoveSpeed => Random.Range(_minMoveSpeed, _maxMoveSpeed);

    private void OnValidate()
    {
        _minMoveSpeed = Mathf.Clamp(_minMoveSpeed, 0.001f, _maxMoveSpeed);
    }
}