public interface IHealable<T>
{
    void Heal(T amount);
    void MaxHeal();
}