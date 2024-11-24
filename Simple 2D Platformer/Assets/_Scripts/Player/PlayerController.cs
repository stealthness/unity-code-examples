using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {

        private PlayerMovement2D _playerMovement2D;

        private void Awake()
        {
            _playerMovement2D = GetComponent<PlayerMovement2D>();
        }
    

        public void Move(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                _playerMovement2D.OnMove(context.ReadValue<Vector2>());
            }
        }
        
        public void Jump(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                _playerMovement2D.OnJump();
            }
        }
    }

    public class Movement2DData : ScriptableObject
    {
        public float speed = 5f;
        public float jumpForce = 5f;
    }
    
    [CreateAssetMenu]
    public class PlayerMovement2DData : Movement2DData
    {
        [Header("Player Layer")] [Tooltip("The layer that the player is on")]
        public float playerLayer;
    }
}
