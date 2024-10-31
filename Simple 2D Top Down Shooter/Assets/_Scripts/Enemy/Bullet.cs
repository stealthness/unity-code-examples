using _Scripts.Core;
using UnityEngine;

namespace _Scripts.Enemy
{
    /// <summary>
    /// A bullet that is lunched from a weapon and travels in a straight line
    /// </summary>
    public class Bullet : Movement2D
    {
        /// <summary>
        /// The life time of the bullet
        /// </summary>
        [SerializeField] private float bulletLifeTime = 3f;
        /// <summary>
        /// The number hit points this bullet will take from the enemy
        /// </summary>
        [SerializeField] private int bulletStrength = 30;
        /// <summary>
        /// The speed of the bullet
        /// </summary>
        [SerializeField] private float bulletSpeed = 10f;
        
        private void Start()
        {
            
            speed = bulletSpeed;
            Invoke(nameof(EndBullet), bulletLifeTime);
        }
        
    
        /// <summary>
        /// Sets the direction of the bullet
        /// </summary>
        /// <param name="direction"></param>
        public void SetDirection(Vector2 direction)
        {
            MovementDirection = direction;
        }
        
        /// <summary>
        /// Ends the bullet and destroys it
        /// </summary>
        public void EndBullet()
        {
            Destroy(gameObject);
        }
        
        /// <summary>
        /// Checks for collision with an enemy and deals damage to it
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Bullet: OnTriggerEnter: " + other.tag);
            if (other.CompareTag("Enemy"))
            {
                other.GetComponent<Enemy>().TakeDamage(bulletStrength);
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// Checks if the bullet has left the game area and destroys it
        /// </summary>
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("GameArea"))
            {
                Destroy(gameObject);
            }
        }
    }
}
