using UnityEngine;

namespace _Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class Pillar : MonoBehaviour
    {
        private Rigidbody2D _rb;
        public float PillarSpeed { get; set; }
        public float PillarHeight { get; set; }
    
    
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }
    
        private void Start()
        {
            _rb.transform.localScale = new Vector3(1, 2 * PillarHeight, 1);
    
            _rb.gravityScale = 0f;
            _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            _rb.linearVelocity = new Vector3(-PillarSpeed, 0, 0);
        }
    }

}

