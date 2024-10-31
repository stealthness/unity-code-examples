namespace _Scripts.Core
{
    public interface IDamageable
    {
        public void TakeDamage(int damage);
        
        public void Die();
        
        public void Heal(int healAmount);
    }
}