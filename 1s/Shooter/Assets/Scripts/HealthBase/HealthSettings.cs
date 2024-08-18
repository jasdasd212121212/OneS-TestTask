using UnityEngine;

[CreateAssetMenu(fileName = "HealthSettings", menuName = "Game design/Health")]
public class HealthSettings : ScriptableObject
{
    [SerializeField][Min(1)] private int _maxHealth;
    
    public int MaxHealth => _maxHealth;
}