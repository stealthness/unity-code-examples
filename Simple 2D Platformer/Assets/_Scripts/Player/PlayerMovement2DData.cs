using UnityEngine;

namespace _Scripts.Player
{
    [CreateAssetMenu]
    public class PlayerMovement2DData : Movement2DData
    {
        [Header("Player Layer")] [Tooltip("The layer that the player is on")]
        public LayerMask playerLayer;
    }
}