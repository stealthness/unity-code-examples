using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    private Rigidbody2D _rb;

    public GameObject explosion;
    public Transform topLimit;
    public Transform bottomLimit;
    [SerializeField] private float playerSpeed = 5f;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.bodyType = RigidbodyType2D.Kinematic;
    }
    

    public void OnMove(InputAction.CallbackContext context)
    {
        
        var y = transform.position.y;
        if (y <= topLimit.position.y && y >= bottomLimit.position.y)
        {
            _rb.linearVelocityY = playerSpeed * context.ReadValue<Vector2>().y;
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
            
            Destroy(this);
        }
    }
    
    

}
