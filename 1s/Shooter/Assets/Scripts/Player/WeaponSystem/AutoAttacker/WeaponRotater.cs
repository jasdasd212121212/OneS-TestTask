using UnityEngine;

public class WeaponRotater : MonoBehaviour
{
    [SerializeField][Min(1)] private float _rotationSpeed = 1000;

    private Transform _cachedTransform;
    private Transform _target;

    private void Awake()
    {
        _cachedTransform = transform;
    }

    private void Update()
    {
        if (_target != null)
        {
            RotateToPoint(_target.position);
        }
        else
        {
            RotateToDirection(-Vector3.up);
        }
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void RotateToPoint(Vector3 point)
    {
        Vector3 directionToPoint = _cachedTransform.position - point;
        RotateToDirection(directionToPoint);
    }

    private void RotateToDirection(Vector3 direction)
    {
        Vector3 rotationBefore = _cachedTransform.eulerAngles;
        _cachedTransform.rotation = Quaternion.RotateTowards(_cachedTransform.rotation, Quaternion.LookRotation(direction, Vector3.forward), _rotationSpeed * Time.deltaTime);

        _cachedTransform.rotation = Quaternion.Euler(rotationBefore.x, rotationBefore.y, _cachedTransform.eulerAngles.z);
    }
}