using UnityEngine;

[CreateAssetMenu(fileName = "AutoAttackerSettings", menuName = "Game design/Player/AutoAttackerSettings")]
public class PlayerAutoAttackerSettings : ScriptableObject
{
    [SerializeField][Min(0.001f)] private float _attackRadius = 5;

    public float AttackRadius => _attackRadius;
}