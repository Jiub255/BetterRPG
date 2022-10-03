public interface IDamageable<T>
{
    void TakeDamage(T damage);
    void Heal(T amount);
    void MaxHeal();
    void Die();
}