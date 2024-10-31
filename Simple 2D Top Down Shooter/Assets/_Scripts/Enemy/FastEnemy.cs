﻿using UnityEngine;

namespace _Scripts.Enemy
{
    public class FastEnemy : Enemy
    {
        protected override void Start()
        {
            base.Start();
            _enemyMovement.speed = 3f;
            InvokeRepeating(nameof(MovementPattern), 0f, 2f);
        }
        
        private void MovementPattern()
        {   
            _enemyMovement.speed = 3f;
            Invoke(nameof(PauseEnemy), 1f);
            _enemyMovement.ChangeDirection();
        }
        
        private void PauseEnemy()
        {
            _enemyMovement.MovementDirection = Vector2.zero;
            _enemyMovement.speed = 0f;
        }

    }
}