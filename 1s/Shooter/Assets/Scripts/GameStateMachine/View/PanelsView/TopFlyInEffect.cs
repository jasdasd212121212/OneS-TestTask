using UnityEngine;
using DG.Tweening;

public class TopFlyInEffect : MonoBehaviour
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
        _transform.position = new Vector3(position.x, position.y + _initialOffset, position.z);

        _transform.DOMove(_targetPoint.position, _duration);
    }
}