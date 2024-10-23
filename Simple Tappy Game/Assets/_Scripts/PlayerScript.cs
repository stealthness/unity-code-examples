using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerScript : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] private float thrustForce = 30f;
    [SerializeField] private bool isThrusting = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


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
            rb.AddForce(thrustForce * Vector2.up);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.gameObject.CompareTag("Piller") )
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
