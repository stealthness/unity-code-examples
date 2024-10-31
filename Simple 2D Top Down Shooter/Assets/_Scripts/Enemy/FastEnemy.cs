using UnityEngine;

namespace _Scripts.Enemy
{
    /// <summary>
    /// This is fast Enemy class, it will move faster than a normal enemy but will pause for a second after every 2 seconds
    /// </summary>
    public class FastEnemy : Enemy
    {
        [SerializeField] private float pauseTime = 1f;
        [SerializeField] private float movementPatternRepeatRate = 1f;
        [SerializeField] private float fastEnemyMovementSpeed = 3f;
        [SerializeField] private float fastEnemyPauseTime = 1f;
        
        /// <summary>
        /// Overriding the start method to set the speed of the enemy and invoke the movement pattern
        /// </summary>
        protected override void Start()
        {
            base.Start();
            _enemyMovement.speed = fastEnemyMovementSpeed;
            InvokeRepeating(nameof(MovementPattern), 0f, movementPatternRepeatRate);
        }
        
        /// <summary>
        /// The movement pattern of the enemy, it will move for 1 second and then pause for 1 second
        /// </summary>
        private void MovementPattern()
        {   
            _enemyMovement.speed = fastEnemyMovementSpeed;
            _enemyMovement.ChangeDirection();
            
            if (fastEnemyPauseTime < movementPatternRepeatRate)
            {
                Invoke(nameof(PauseEnemy), fastEnemyPauseTime);
            }
        }
        
        /// <summary>
        /// Pauses the enemy for 1 second
        /// </summary>
        private void PauseEnemy()
        {
            _enemyMovement.MovementDirection = Vector2.zero;
            _enemyMovement.speed = 0f;
        }
    }
}