using UnityEngine;


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



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.GetButtonDown("Fire1"))
        {
            isThrusting=true;
        }
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0) || Input.GetButtonUp("Fire1"))
        {
            isThrusting=false;
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
