using _Scripts.Core;
using UnityEngine;


namespace _Scripts.Player
{
    public class PlayerMovement : Movement2D
    {
        private void Start()
        {
            Speed = 5f;
        }

        public void SetMovementDirection(Vector2 direction)
        {
            MovementDirection = direction;
        }
    }

}

