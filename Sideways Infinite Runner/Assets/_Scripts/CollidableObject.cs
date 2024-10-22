using System;
using UnityEngine;

namespace _Scripts
{
    [RequireComponent(typeof(CircleCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class CollidableObject : MonoBehaviour
    {
    
        private CircleCollider2D _circleCollider;
        private Rigidbody2D _rb;
    
        [SerializeField] private float speed = 5f;
    
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _rb.bodyType = RigidbodyType2D.Kinematic;
            _circleCollider = GetComponent<CircleCollider2D>();
            _circleCollider.isTrigger = true;
            _rb.linearVelocityX = -speed;
        }

        private void Start()
        {
            _rb.linearVelocityX = -speed;
        }
    }
}

