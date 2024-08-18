using DG.Tweening;
using UnityEngine;

public class SideFlyInEffect : MonoBehaviour
{
    [SerializeField] private float _initialOffset;
    [SerializeField] private Transform _targetPoint;
    [SerializeField][Min(0.01f)] private float _duration;

    private RectTransform _transform;

    private void Awake()
    {
        _transform = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        Vector3 position = _transform.position;
        _transform.position = new Vector3(position.x + _initialOffset, position.y, position.z);

        _transform.DOMove(_targetPoint.position, _duration);
    }
}