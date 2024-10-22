using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Piller : MonoBehaviour
{
    private Rigidbody2D rb;
    public float pillerSpeed { get; set; }
    public float pillerHeight { get; set; }


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rb.transform.localScale = new Vector3(1, 2 * pillerHeight, 1);

        rb.gravityScale = 0f;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.linearVelocity = new Vector3(-pillerSpeed, 0, 0);
    }
}
