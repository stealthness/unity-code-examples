using _Scripts.Core;
using _Scripts.Managers;
using UnityEngine;

namespace _Scripts.Enemy
{
    /// <summary>
    /// Enemy class that is the base class for all enemies in the game
    /// </summary>
    [RequireComponent(typeof(EnemyMovement))]
    public abstract class Enemy : MonoBehaviour, IDamageable
    {
        /// <summary>
        /// A reference to the EnemyMovement component and is accessed by the derived classes.
        /// </summary>
        protected EnemyMovement _enemyMovement;
        /// <summary>
        /// The maximum health of the enemy, with a default value of 100.
        /// </summary>
        private int _maxHealth = 100;
        /// <summary>
        /// The current health of the enemy.
        /// </summary>
        private int _health;

        /// <summary>
        /// Awake is called when the script instance is being loaded and will reference the EnemyMovement component.
        /// </summary>
        private void Awake()
        {
            _enemyMovement = GetComponent<EnemyMovement>();
        }
        
        /// <summary>
        /// Start is called before the first frame update and will set the health of the enemy to the maximum health and
        /// the speed of the enemy to 1. It is accessed by the derived classes.
        /// </summary>
        protected virtual void Start()
        {
            _health = _maxHealth;
            _enemyMovement.speed = 1f;
        }

        /// <summary>
        /// Checks for collision with the player and ends the game if the player collides with the enemy.
        /// </summary>
        /// <param name="other"></param>
        private void OnCollisionEnter2D(Collision2D other)
        {
            Debug.Log("Enemy: OnCollisionEnter: " + other.gameObject.tag);
            if (other.gameObject.CompareTag("Player"))
            {
                FindAnyObjectByType<CameraFollow>().StopFollowing();
                Destroy(other.gameObject);
 
                GameManager.Instance.GameOver();
            }
        }

        /// <summary>
        /// Called when the enemy takes damage and will reduce the health of the enemy by the damage amount. If the health
        ///  is less than or equal to 0, the health is set to 0 and the Die method is called.
        /// </summary>
        /// <param name="damage"></param>
        public void TakeDamage(int damage)
        {
            _health -= damage;
            if (_health <= 0)
            {
                _health = 0;
                Die();
            }
        }

        /// <summary>
        /// Called when the enemy dies and will destroy the enemy game object.
        /// </summary>
        public void Die()
        {
            Destroy(this.gameObject);
        }

        /// <summary>
        /// Heals the enemy by the heal amount and will not exceed the maximum health.
        /// </summary>
        /// <param name="healAmount"></param>
        public void Heal(int healAmount)
        {
            _health = Mathf.Min(_health + healAmount, _maxHealth);
        }
    }
}