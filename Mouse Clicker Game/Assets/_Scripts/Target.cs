using System;
using UnityEngine;

namespace _Scripts
{
    
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class Target : MonoBehaviour
    {
        private Rigidbody2D _rb;
        private Collider2D _collider;
        private SpriteRenderer _sr;
        
        private void Awake()
        {
            _collider  = GetComponent<Collider2D>();
            _sr = GetComponent<SpriteRenderer>();
            _rb = GetComponent<Rigidbody2D>();
        }


        public void DestroyTarget()
        {
            _collider.enabled = false;
            _sr.color = Color.black;
            Invoke(nameof(DelayedDestroy), 0.3f);
        }


        public void DelayedDestroy()
        {
            Destroy(gameObject);
        }

    }
}
