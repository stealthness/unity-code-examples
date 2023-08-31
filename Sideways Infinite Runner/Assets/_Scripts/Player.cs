using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    public Transform topLimit;
    public Transform bottomLimit;
    [SerializeField] private float playerSpeed = 5f;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    private void Update()
    {
        var y = Input.GetAxis("Vertical");
        if (y > 0 && transform.position.y < topLimit.position.y)
        {
            transform.Translate(playerSpeed * y * Time.deltaTime * Vector3.up);
        }
        if (y < 0 && transform.position.y > bottomLimit.position.y)
        {
            transform.Translate(playerSpeed * y * Time.deltaTime * Vector3.up);
        }


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collidable"))
        {
            Debug.Log("Ouch");
            Time.timeScale = 0f;
        }
    }

}
