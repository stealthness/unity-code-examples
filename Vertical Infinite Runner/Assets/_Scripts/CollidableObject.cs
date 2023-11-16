using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class CollidableObject : MonoBehaviour
{

    private BoxCollider2D box;
    [SerializeField] private float speed = 5f;

    private void Awake()
    {
        box = GetComponent<BoxCollider2D>();
        box.isTrigger = true;
    }

    private void Update()
    {
        transform.Translate(Time.deltaTime * speed * Vector3.down);
    }


}
