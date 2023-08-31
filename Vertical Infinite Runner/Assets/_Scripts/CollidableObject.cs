using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CollidableObject : MonoBehaviour
{

    [SerializeField] private float speed = 5f;


    private void Update()
    {
        transform.Translate(Time.deltaTime * speed * Vector3.down);
    }


}
