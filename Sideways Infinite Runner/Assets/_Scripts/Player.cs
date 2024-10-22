using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        private Rigidbody2D _rb;
    
        public GameObject explosion;
        public Transform topLimit;
        public Transform bottomLimit;
        [SerializeField] private float playerSpeed = 3f;
    
    
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _rb.bodyType = RigidbodyType2D.Kinematic;
        }
    
 
    
        public void OnMove(InputAction.CallbackContext context)
        {
            
            var y = transform.position.y;
            var inputY = playerSpeed * context.ReadValue<Vector2>().y;
            if ((inputY > 0 && y <= topLimit.position.y) ||
                (inputY < 0 && y >= bottomLimit.position.y))
            {
                _rb.linearVelocityY = playerSpeed * inputY ;
            }
            else
            {
                _rb.linearVelocityY = 0f;
            }
        }
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Collidable"))
            {
                Debug.Log("Ouch");
                explosion.SetActive(true);
                explosion.transform.position = transform.position;
                CollidableManager.Instance.StopSpawning();
                GameManager.Instance.EndGame();
                Destroy(collision);
            } else if (collision.CompareTag("Coin"))
            {
                GameManager.Instance.addScore(10);
                Destroy(collision);
            }
        }

    }

}

