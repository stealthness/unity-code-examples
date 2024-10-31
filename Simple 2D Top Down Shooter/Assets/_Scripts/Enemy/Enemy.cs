using _Scripts.Core;
using _Scripts.Managers;
using UnityEngine;

namespace _Scripts.Enemy
{
    
    [RequireComponent(typeof(EnemyMovement))]
    public class Enemy : MonoBehaviour
    {
        private EnemyMovement _enemyMovement;

        private void Awake()
        {
            _enemyMovement = GetComponent<EnemyMovement>();
        }
        
        private void Start()
        {
            _enemyMovement.Speed = 1f;
            InvokeRepeating(nameof(_enemyMovement.ChangeDirection), 0f, 0.2f);
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