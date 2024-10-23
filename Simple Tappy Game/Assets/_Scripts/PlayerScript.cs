using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerScript : MonoBehaviour
    {
    
        private Rigidbody2D _rb;
        [SerializeField] private float thrustForce = 30f;
        [SerializeField] private bool isThrusting;
    
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }
    
        /// <summary>
        /// OnJump, whilst jump is pressed set is thrusting to true
        /// </summary>
        /// <param name="context"></param>
        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                isThrusting = true;
            }
            else if (context.canceled)
            {
                isThrusting = false;
            }
        }
        
    
        private void FixedUpdate()
        {
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
                Time.timeScale = 0f;
            }
        }
    
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Ceiling"))
            {
                Debug.Log("Splat");
                Time.timeScale = 0f;
            }
        }
    }

}

