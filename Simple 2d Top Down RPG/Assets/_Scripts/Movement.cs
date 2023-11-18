using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Movement : MonoBehaviour
{
    Collider2D box;
    Rigidbody2D rb;

    [SerializeField] protected float speed = 1f;


    private void Awake()
    {
        box = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    protected void MoveDir(Vector2 dir)
    {
        transform.Translate(Time.deltaTime * dir * speed);
    }

}
