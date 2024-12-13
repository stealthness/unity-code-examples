using UnityEngine;

namespace _Scripts
{
    public class Highlight : MonoBehaviour
    {
    
        [SerializeField] private SpriteRenderer highlightedSprite;

        private void Start()
        {
            highlightedSprite.enabled = false;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                
                highlightedSprite.enabled = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                highlightedSprite.enabled = false;
            }
        }
    }
}
