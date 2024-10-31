using _Scripts.Core;
using UnityEngine;


namespace _Scripts.Player
{
    public class PlayerMovement : Movement2D
    {

        public void SetMovementDirection(Vector2 direction)
        {
            MovementDirection = direction;
        }
    }

}

