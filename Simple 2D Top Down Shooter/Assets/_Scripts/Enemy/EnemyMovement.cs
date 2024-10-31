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
            InvokeRepeating(nameof(ChangeDirection), 0f, _changeDirectionUpdateFequency);
        }
        
        private void ChangeDirection()
        {
            MovementDirection = (EnemyManager.Instance.GetTarget() - transform.position).normalized;
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
    }
}
