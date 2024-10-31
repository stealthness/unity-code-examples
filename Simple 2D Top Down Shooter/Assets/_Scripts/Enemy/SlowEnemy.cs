using _Scripts.Player;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace _Scripts.Enemy
{
    
    
    public class SlowEnemy : Enemy
    {

        private EnemyMovement _enemyMovement;
        
        
        private void Awake()
        {
            _enemyMovement = GetComponent<EnemyMovement>();
        }
        
        private void Start()
        {
            _enemyMovement.Speed = 1f;
            InvokeRepeating(nameof(_enemyMovement.ChangeDirection), 0f, 0.3f);
        }
        

        
        
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Destroy(other.gameObject);
            }
        }
    }
    

}