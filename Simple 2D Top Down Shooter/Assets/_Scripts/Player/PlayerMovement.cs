using _Scripts.Core;
using UnityEngine;


namespace _Scripts.Player
{
    /// <summary>
    /// PlayerMovement class that is responsible for handling player movement
    /// </summary>
    public class PlayerMovement : Movement2D
    {
        private void Start()
        {
            speed = 5f;
        }

        /// <summary>
        /// Sets the direction of the player
        /// </summary>
        /// <param name="direction"></param>
        public void SetMovementDirection(Vector2 direction)
        {
            MovementDirection = direction;
        }
    }

}

