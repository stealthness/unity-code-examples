namespace _Scripts.Core
{
    /// <summary>
    /// This interface is used to define the methods that a damageable object should have.
    /// </summary>
    public interface IDamageable
    {
        /// <summary>
        /// This method is used to take damage.
        /// </summary>
        public void TakeDamage(int damage);
        
        /// <summary>
        /// This method is used when the object dies.
        ///  </summary>
        public void Die();
        
        /// <summary>
        /// Heals the object by the healAmount
        /// </summary>
        /// <param name="healAmount"></param>
        public void Heal(int healAmount);
    }
}