using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts.Player
{
    
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody2D _rb;
        
        [SerializeField] private float speed = 5f;
        [SerializeField] private float jumpForce = 10f;
        [SerializeField] private Vector2 direction;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _rb.gravityScale = 0;
            _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        private void Start()
        {
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                direction = context.ReadValue<Vector2>();
                
            }
            if (context.canceled)
            {
                direction = Vector2.zero;
            }
        }

        private void LateUpdate()
        {
            _rb.linearVelocity = speed * new Vector2(direction.x, direction.y);
        }
    }
}