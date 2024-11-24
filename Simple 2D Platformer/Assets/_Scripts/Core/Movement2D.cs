
using _Scripts.Player;
using UnityEngine;

namespace _Scripts.Core
{
    
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Movement2D : MonoBehaviour
    {
        [SerializeField] internal Movement2DData stats;
        internal Rigidbody2D rigidbody2D;
        [SerializeField] protected bool isGrounded;

        protected virtual void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }
        


        protected internal virtual void OnMove(Vector2 direction)
        {
            if (isGrounded)
            {
                rigidbody2D.linearVelocity = stats.speed * new Vector2(direction.x, 0);
            }
            else
            {
                rigidbody2D.linearVelocity = new Vector2(stats.speed * direction.x, rigidbody2D.linearVelocity.y);
            }
            
        }
        
        protected internal virtual void OnJump()
        {
            if (isGrounded)
            {
                rigidbody2D.AddForce(Vector2.up * stats.jumpForce, ForceMode2D.Impulse);
            }
        }
    }
}
