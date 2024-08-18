using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private PlayerMoverSettings _settings;

    [Inject] private IMoveInputSystem _input;

    private Rigidbody2D _selfRigidbody;

    private void Awake()
    {
        _selfRigidbody = GetComponent<Rigidbody2D>();

        _selfRigidbody.gravityScale = 0f;
    }

    private void FixedUpdate()
    {
        Vector2 inputVector = _input.InputVector;

        _selfRigidbody.MovePosition(_selfRigidbody.position + inputVector.normalized * _settings.MoveSpeed);
    }
}