using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class CollidableObject : MonoBehaviour
{

    private BoxCollider2D box;

    private void Awake()
    {
        box = GetComponent<BoxCollider2D>();
        box.isTrigger = true;
    }

    private void Update()
    {
        transform.Translate(Time.deltaTime * GameManager.Instance.GameSpeed * Vector3.down);
    }


}
