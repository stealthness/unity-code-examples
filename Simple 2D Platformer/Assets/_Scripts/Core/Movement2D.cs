using _Scripts.Player;
using UnityEngine;

namespace _Scripts.Core
{
    
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Movement2D : MonoBehaviour
    {
        protected Rigidbody2D rigidbody2D;
        [SerializeField] protected float jumpForce = 5f;
        [SerializeField] protected bool isGrounded;

        [SerializeField] protected float speed = 5f;

        protected virtual void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }
        
        
        protected internal virtual void OnMove(Vector2 direction)
        {
            if (isGrounded)
            {
                rigidbody2D.linearVelocity = speed * new Vector2(direction.x, 0);
            }
            else
            {
                rigidbody2D.linearVelocity = new Vector2(speed * direction.x, rigidbody2D.linearVelocity.y);
            }
            
        }
        
        protected internal virtual void OnJump()
        {
            if (isGrounded)
            {
                rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }
}
