using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Movement : MonoBehaviour
{
    internal Collider2D box;
    Rigidbody2D rb;
    internal SpriteRenderer sr;

    [SerializeField] protected float speed = 1f;


    private void Awake()
    {
        box = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }


    protected void MoveDir(Vector2 dir)
    {
        transform.Translate(Time.deltaTime * dir * speed);
        CheckFlipSprite(dir);
    }

    /// <summary>
    /// Check weather the Movement spite is need to be fliped based on the direction dir.x
    /// </summary>
    /// <param name="dir">objects movement directions</param>
    private void CheckFlipSprite(Vector2 dir)
    {
        // flip sprite if moving to left
        if (dir.x < 0)
        {
            sr.flipX = true;
        }
        if (dir.x > 0)
        {
            sr.flipX = false;
        }
        // dir.x == 0 do nougthing
    }
}
