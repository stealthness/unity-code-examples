using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts.Player
{
    
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody2D _rb;
        private SpriteRenderer _sr;
        private PlayerAnimator _playerAnimator;
        
        [SerializeField] private float speed = 5f;
        [SerializeField] private float jumpForce = 10f;
        [SerializeField] private Vector2 direction;
        [SerializeField] private float _TOL = 001f;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _rb.gravityScale = 0;
            _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            _playerAnimator = GetComponent<PlayerAnimator>();
            _sr = GetComponent<SpriteRenderer>();
        }
        

        public void OnMove(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                direction = context.ReadValue<Vector2>();
                ChangeDirection();
                _playerAnimator.PlayAnimation(PlayerAnimation.Moving);
                
                
            }
            if (context.canceled)
            {
                direction = Vector2.zero;
                _playerAnimator.PlayAnimation(PlayerAnimation.Idle);
            }
        }

        private void LateUpdate()
        {
            _rb.linearVelocity = speed * new Vector2(direction.x, direction.y);
        }

        void ChangeDirection()
        {
            if (direction.x < _TOL)
            {
                _sr.flipX = true;
            }else if (direction.x > _TOL)
            {
                _sr.flipX = false;
            }
            
            
        }
    }
}