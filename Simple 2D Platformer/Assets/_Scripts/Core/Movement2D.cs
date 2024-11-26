using _Scripts.Player;
using UnityEngine;

namespace _Scripts.Core
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Movement2D : MonoBehaviour
    {
        [SerializeField] internal Movement2DData stats;
        [SerializeField] protected bool isGrounded;
        protected Rigidbody2D rigidbody2D;
        protected SpriteRenderer spriteRenderer;
        protected Vector2 _direction;

        protected virtual void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void FixedUpdate()
        {
            rigidbody2D.linearVelocity = new Vector2(stats.speed * _direction.x, rigidbody2D.linearVelocity.y);
        }


        protected internal virtual void OnMove(Vector2 direction)
        {
            _direction = direction;
            if (isGrounded)
            {
                rigidbody2D.linearVelocity = stats.speed * new Vector2(direction.x, 0);
            }
            else
            {
                rigidbody2D.linearVelocity = new Vector2(stats.speed * direction.x, rigidbody2D.linearVelocity.y);
            }

            CheckDirection();
        }

        private void CheckDirection()
        {
            if (rigidbody2D.linearVelocityX > 0)
            {
                spriteRenderer.flipX = false;
            }
            else if (rigidbody2D.linearVelocityX < 0)
            {
                spriteRenderer.flipX = true;
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
