using System;
using _Scripts.Core;
using UnityEngine;

namespace _Scripts.Enemy
{
    public class Bullet : Movement2D
    {
        
        [SerializeField] private float bulletLifeTime = 3f;
        private void Start()
        {
            Speed = 10f;
            Invoke(nameof(EndBullet), bulletLifeTime);
        }
        
    
        public void SetDirection(Vector2 direction)
        {
            MovementDirection = direction;
        }
        
        public void EndBullet()
        {
            Destroy(gameObject);
        }
        

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("GameArea"))
            {
                Destroy(gameObject);
            }
        }
    }
}
