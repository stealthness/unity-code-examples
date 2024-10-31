using _Scripts.Core;
using _Scripts.Managers;
using UnityEngine;

namespace _Scripts.Enemy
{
    /// <summary>
    /// EnemyMovement class that is the base class for all enemy movement in the game
    /// </summary>
    public class EnemyMovement : Movement2D
    {
        /// <summary>
        /// The default frequency at which the direction of the enemy will change
        /// </summary>
        //[SerializeField]private float changeDirectionUpdateFrequency = 0.5f;
        
        /// <summary>
        /// Start is called before the first frame update and will start InvokeRepeatable ChangeDirection method
        /// </summary>
        void Start()
        {
            //InvokeRepeating(nameof(ChangeDirection), 0f, changeDirectionUpdateFrequency);
        }

        /// <summary>
        /// Changes the direction of the enemy to the direction of the target
        /// </summary>
        public void ChangeDirection()
        {
            MovementDirection = (EnemyManager.Instance.GetTarget() - transform.position).normalized;
        }
        

    }
}
