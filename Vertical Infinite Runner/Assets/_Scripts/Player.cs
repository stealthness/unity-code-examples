using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    public Transform leftLimit;
    public Transform rightLimit;
    [SerializeField] private float playerSpeed = 5f;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.bodyType = RigidbodyType2D.Kinematic;
    }

    private void Update()
    {
        var x = Input.GetAxis("Horizontal");
        if (x > 0 && transform.position.x < rightLimit.position.x)
        {
            transform.Translate(playerSpeed * x * Time.deltaTime * Vector3.right);
        }
        if (x < 0 && transform.position.x > leftLimit.position.x)
        {
            transform.Translate(playerSpeed * x * Time.deltaTime * Vector3.right);
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
