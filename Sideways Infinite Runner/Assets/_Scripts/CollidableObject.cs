using UnityEngine;

namespace _Scripts
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class CollidableObject : MonoBehaviour
    {
    
        private BoxCollider2D _box;
        private Rigidbody2D _rb;
    
        [SerializeField] private float speed = 5f;
    
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _rb.bodyType = RigidbodyType2D.Kinematic;
            _box = GetComponent<BoxCollider2D>();
            _box.isTrigger = true;
        }
    
        private void Update()
        {
            transform.Translate(Time.deltaTime * speed * Vector3.left);
        }
    }
}

