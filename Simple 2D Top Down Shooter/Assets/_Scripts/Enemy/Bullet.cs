using System;
using _Scripts.Core;
using UnityEngine;

namespace _Scripts.Enemy
{
    public class Bullet : Movement2D
    {
        private void Start()
        {
            Speed = 10f;
        }
        
    
        public void SetDirection(Vector2 direction)
        {
            MovementDirection = direction;
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
