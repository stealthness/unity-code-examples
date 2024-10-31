using UnityEngine;

namespace _Scripts.Core
{
    
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class Movement2D : MonoBehaviour
    {
        protected Rigidbody2D Rb;

        protected Vector2 MovementDirection;
        
        protected float Speed = 1f;

        private void Awake()
        {
            Rb = GetComponent<Rigidbody2D>();
        }


        protected void Update()
        {
            transform.position += (Vector3) MovementDirection * (Speed * Time.deltaTime);
        }
    }
}
