using UnityEngine;

[CreateAssetMenu(fileName = "MoverSettings", menuName = "Game design/Player/CharacterMoveSettings")]
public class PlayerMoverSettings : ScriptableObject
{
    [SerializeField][Min(0.000001f)] private float _moveSpeed = 10f;

    public float MoveSpeed => _moveSpeed;
}