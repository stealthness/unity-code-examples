using _Scripts.Core;
using UnityEngine;

namespace _Scripts.Player
{
    public class PlayerMovement2D : Movement2D
    {
        
        protected override void Awake()
        {
            base.Awake();
            rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        
        
        private void Start()
        {
            isGrounded = true;
        }
        
        private void CheckGrounded()
        {
            var hit = Physics2D.Raycast(transform.position, Vector2.down, 1f);
            if (hit.collider != null)
            {
                Debug.Log("Hit: " + hit.collider.tag);
                
                if (hit.collider.CompareTag("Ground"))
                {
                    isGrounded = true;
                }
            }
            else
            {
                isGrounded = false;
            }
        }
    }
}
