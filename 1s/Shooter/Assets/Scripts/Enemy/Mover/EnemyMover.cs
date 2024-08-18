using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private EnemyMoveSettings _settings;

    private Transform _cahcedTransform;

    private float _moveSpeed;

    public Transform CachedTransform => _cahcedTransform;

    private void Awake()
    {
        _cahcedTransform = transform;
    }

    private void OnEnable()
    {
        _moveSpeed = _settings.RandomMoveSpeed;
    }

    private void Update()
    {
        _cahcedTransform.Translate(-_cahcedTransform.up * _moveSpeed * Time.deltaTime);
    }
}