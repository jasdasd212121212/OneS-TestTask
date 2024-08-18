public interface IDamageble
{
    int MaxHealth { get; }
    int CurrentHealth { get; }
    void TakeDamage(int damage);
}