using UnityEngine;

namespace _Scripts
{
    public class ScrollingBackground : MonoBehaviour
    {
        [SerializeField] private float scrollSpeed = 2f;
    
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            
        }
    
        // Update is called once per frame
        void Update()
        {
            transform.Translate(scrollSpeed * Time.deltaTime * Vector3.left);
            
            
            if (transform.position.x < -10)
            {
                transform.Translate(new Vector3(10f,0,0));
            }
        }
    }

}

