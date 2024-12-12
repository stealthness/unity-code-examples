using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts.Player
{
    
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(PlayerAnimator))]
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody2D _rb;
        private SpriteRenderer _sr;
        private PlayerAnimator _playerAnimator;
        
        [SerializeField] private float speed = 5f;
        [SerializeField] private float jumpForce = 10f;
        [SerializeField] private Vector2 direction;
        private const float Tol = 0.01f;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _rb.gravityScale = 0;
            _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            _playerAnimator = GetComponent<PlayerAnimator>();
            _sr = GetComponent<SpriteRenderer>();
        }
        

        /// <summary>
        /// OnMove is called when the player moves
        /// </summary>
        /// <param name="context"></param>
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

        /// <summary>
        ///  Change the direction of the sprite as per the direction of the player
        /// </summary>
        void ChangeDirection()
        {
            if (direction.x < -Tol)
            {
             _sr.flipX = true;
            }
            if (direction.x > Tol)
            {
             _sr.flipX = false;
            }               
        }
    }
}