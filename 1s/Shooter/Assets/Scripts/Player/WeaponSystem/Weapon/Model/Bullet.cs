using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(CapsuleCollider2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField][Min(1f)] private float _destroyDelay;

    private Rigidbody2D _selfRigidbody;
    private Transform _cachedTransform;

    private int _damage;
    private bool _initialized;

    public Transform CachedTransform => _cachedTransform;

    private void OnEnable()
    {
        Destroy(gameObject, _destroyDelay);
    }

    public void Launch(int damage, float speed)
    {
        Initialize();

        if (damage <= 0)
        {
            Debug.LogError($"Critical error -> bullet can`t has a damage <= 0");
            damage = 1;
        }

        _damage = damage;

        _selfRigidbody.velocity = Vector3.zero;
        _selfRigidbody.AddForce(_cachedTransform.up * speed, ForceMode2D.Impulse);
    }

    private void Initialize()
    {
        if (_initialized)
        {
            return;
        }

        _selfRigidbody = GetComponent<Rigidbody2D>();
        _cachedTransform = transform;

        _initialized = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out IDamageble damageble))
        {
            damageble.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}