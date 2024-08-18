using UnityEngine;

[CreateAssetMenu(fileName = "EnemyAttackSettigs", menuName = "Game design/Enemy/Attack settings")]
public class EnemyAttackSettings : ScriptableObject
{
    [SerializeField][Min(1)] private int _damage;

    public int Damage => _damage;
}