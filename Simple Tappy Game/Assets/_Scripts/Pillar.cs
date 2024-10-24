using UnityEngine;

namespace _Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class Pillar : MonoBehaviour
    {
        private GameObject _topColumn;
        private GameObject _bottomColumn;
        
        public float bottomColumnHeightOffset = 0f;
        public float topColumnHeightOffset =0f;
        
        private const float LeftEdge = -20f;
        private Rigidbody2D _rb;

    
    
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }
    
        private void Start()
        {

            
            _rb.gravityScale = 0f;
            _rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;
        }
        
        private void Update()
        {
            if (transform.position.x < LeftEdge)
            {
                Destroy(gameObject);
            }
        } 
    }

}

