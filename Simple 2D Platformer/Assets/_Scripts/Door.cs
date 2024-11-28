using System;
using UnityEngine;

namespace _Scripts
{
    public class Door : MonoBehaviour
    {

        private BoxCollider2D _boxCollider2D;
        private SpriteRenderer _spriteRenderer;

        public Sprite openSprite;
        public Sprite closeSprite;
        

        private void Awake()
        {
            _boxCollider2D = GetComponent<BoxCollider2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            _spriteRenderer.sprite = closeSprite;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _spriteRenderer.sprite = openSprite;
            }
            
        }


        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _spriteRenderer.sprite = closeSprite;
                
            }
        }
    }
}
