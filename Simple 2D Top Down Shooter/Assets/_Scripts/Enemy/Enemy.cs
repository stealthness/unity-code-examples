using _Scripts.Core;
using _Scripts.Managers;
using UnityEngine;

namespace _Scripts.Enemy
{
    
    [RequireComponent(typeof(EnemyMovement))]
    public abstract class Enemy : MonoBehaviour, IDamageable
    {
        protected EnemyMovement _enemyMovement;
        
        private int _maxHealth = 100;
        private int _health;

        private void Awake()
        {
            _enemyMovement = GetComponent<EnemyMovement>();
        }
        
        protected virtual void Start()
        {
            _health = _maxHealth;
            _enemyMovement.speed = 1f;
        }

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

        public void TakeDamage(int damage)
        {
            _health -= damage;
            if (_health <= 0)
            {
                _health = 0;
                Die();
            }
        }

        public void Die()
        {
            Destroy(this.gameObject);
        }

        public void Heal(int healAmount)
        {
            _health = Mathf.Min(_health + healAmount, _maxHealth);
        }
    }
}