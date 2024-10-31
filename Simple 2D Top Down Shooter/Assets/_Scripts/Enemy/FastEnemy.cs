using UnityEngine;

namespace _Scripts.Enemy
{
    public class FastEnemy : Enemy
    {
        
        private EnemyMovement _enemyMovement;
        
        
        private void Awake()
        {
            _enemyMovement = GetComponent<EnemyMovement>();
        }
        private void Start()
        {
            _enemyMovement.Speed = 3f;
            InvokeRepeating(nameof(MovementPattern), 0f, 2f);
        }
        
        private void MovementPattern()
        {   
            _enemyMovement.Speed = 3f;
            Invoke(nameof(PauseEnemy), 1f);
            _enemyMovement.ChangeDirection();
        }
        
        private void PauseEnemy()
        {
            _enemyMovement.MovementDirection = Vector2.zero;
            _enemyMovement.Speed = 0f;
        }

    }
}