using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerScript : MonoBehaviour
    {
        private Animator _animator;
        private Rigidbody2D _rb;
        private bool _isDead;
        [SerializeField] private float thrustForce = 30f;
        [SerializeField] private bool isThrusting;
        private static readonly int IsFlying = Animator.StringToHash("IsFlying");
        private static readonly int IsDead = Animator.StringToHash("IsDead");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _isDead = false;
        }

        /// <summary>
        /// OnJump, whilst jump is pressed set is thrusting to true
        /// </summary>
        /// <param name="context"></param>
        public void OnJump(InputAction.CallbackContext context)
        {
            if (_isDead)
            {
                return;
            }
            
            if (context.started)
            {
                isThrusting = true;
                _animator.SetBool(IsFlying, true);
            }
            else if (context.canceled)
            {
                isThrusting = false;
                _animator.SetBool(IsFlying, false);
            }
        }
        
    
        private void FixedUpdate()
        {
            if (_isDead)
            {
                return;
            }
            
            
            if (isThrusting)
            {
                //Debug.Log("Flap");
                _rb.AddForce(thrustForce * Vector2.up);
            }
    
        }
    
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if ( collision.gameObject.CompareTag("Pillar") )
            {
                Debug.Log("Splat");
                Die();
            }
        }
    
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Ceiling"))
            {
                Debug.Log("Splat");
                Die();
            }
        }

        private void Die()
        {
            _isDead = true;
            _animator.SetTrigger(IsDead);
            // need to be change later to game speed
            _rb.linearVelocityX = -3f;
            _rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            UIMenu.Instance.ShowEndPanel();
        }
    }

}

