using _Scripts.Core;
using UnityEngine;

namespace _Scripts.Player
{
    
    public class PlayerMovement2D : Movement2D
    {
        
        private BoxCollider2D _boxCollider2D;
        private PlayerMovement2DData PlayerStats => (PlayerMovement2DData)stats;
        private int _currentJumpCount;
        
        protected override void Awake()
        {
            base.Awake();
            _boxCollider2D = GetComponent<BoxCollider2D>();
            rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        protected internal override void OnJump()
        {
            Debug.Log("PlayerMovement2D: Jump");
            if (isGrounded)
            {
                _currentJumpCount = PlayerStats.maxJumps;
                base.OnJump();
            }
            else
            {
                if (_currentJumpCount <= 0)
                {
                    return;
                }
                
                var force = stats.jumpForce;
                if (rigidbody2D.linearVelocity.y < 0)
                {
                    force -= rigidbody2D.linearVelocity.y;
                }
                
                rigidbody2D.AddForce(Vector2.up * force, ForceMode2D.Impulse);
                _currentJumpCount--;
            }
        }


        private void Start()
        {
            isGrounded = true;
            _currentJumpCount = PlayerStats.maxJumps;
        }

        private void Update()
        {
            CheckGrounded();
        }

        
        private void CheckGrounded()
        {
            var center = _boxCollider2D.bounds.center;
            var size = _boxCollider2D.size;
            var hit = Physics2D.BoxCast(center, size , 0, Vector2.down, 0.05f, ~PlayerStats.playerLayer);
            
            isGrounded = hit && hit.collider.CompareTag("Ground");
            
        }

        /// <summary>
        /// DeadStop is called when the player dies. It stops the player from moving and falling.
        /// </summary>
        public void DeadStop()
        {
            _direction = Vector2.zero;
            rigidbody2D.gravityScale = 0;
            rigidbody2D.linearVelocity = Vector2.zero;
        }
    }
}
