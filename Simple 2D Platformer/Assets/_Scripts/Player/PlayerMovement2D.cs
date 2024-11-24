using System;
using _Scripts.Core;
using UnityEngine;

namespace _Scripts.Player
{
    
    public class PlayerMovement2D : Movement2D
    {
        private BoxCollider2D _boxCollider2D;
        
        protected override void Awake()
        {
            base.Awake();
            _boxCollider2D = GetComponent<BoxCollider2D>();
            rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        
        
        private void Start()
        {
            isGrounded = true;
        }

        private void Update()
        {
            CheckGrounded();
        }

        private void CheckGrounded()
        {
            var mask = LayerMask.GetMask( "Ground");
            var center = _boxCollider2D.bounds.center;
            var size = _boxCollider2D.size;
            var hit = Physics2D.BoxCast(center, size, 0, Vector2.down, 0.05f, mask);
            
            if (hit)
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
