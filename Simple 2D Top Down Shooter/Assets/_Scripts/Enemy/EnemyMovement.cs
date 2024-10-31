using System;
using _Scripts.Core;
using _Scripts.Managers;
using UnityEngine;

namespace _Scripts.Enemy
{
    public class EnemyMovement : Movement2D
    {

        [SerializeField]private float _changeDirectionUpdateFequency = 0.5f;

        private void Start()
        {
            Speed = 1f;
            InvokeRepeating(nameof(changeDirection), 0f, _changeDirectionUpdateFequency);
        }
        
        private void changeDirection()
        {
            MovementDirection = (EnemyManager.Instance.GetTarget() - transform.position).normalized;
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("OnTriggerEnter: " + other.tag);
            if (other.CompareTag("Player"))
            {
                Destroy(other.gameObject);
                GameManager.Instance.GameOver();
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            Debug.Log("OnCollisionEnter: " + other.gameObject.tag);
            if (other.gameObject.CompareTag("Player"))
            {
                Destroy(other.gameObject);
                GameManager.Instance.GameOver();
            }
        }
    }
}
