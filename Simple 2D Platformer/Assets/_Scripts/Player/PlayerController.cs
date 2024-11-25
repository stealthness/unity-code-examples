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
            if (context.phase == InputActionPhase.Performed || context.phase == InputActionPhase.Started)
            {
                _playerMovement2D.OnMove(context.ReadValue<Vector2>());
            }
            
            if (context.phase == InputActionPhase.Canceled)
            {
                _playerMovement2D.OnMove(Vector2.zero);
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
}
