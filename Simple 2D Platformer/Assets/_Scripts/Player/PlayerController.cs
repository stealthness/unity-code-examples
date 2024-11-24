using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerMovement2DData stats;
        private PlayerMovement2D _playerMovement2D;

        private void Awake()
        {
            _playerMovement2D = GetComponent<PlayerMovement2D>();
            _playerMovement2D.stats = stats;
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
}
