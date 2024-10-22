using UnityEngine;
using Random = UnityEngine.Random;

namespace _Script
{
    public class CollidableManager : MonoBehaviour
    {
        public static CollidableManager Instance { get; private set; }
    
        public Transform topLimit;
        public Transform bottomLimit;
        public GameObject collidableObjectPrefab;
    
        [SerializeField] private float minFrequencyTime = 0.1f;
        [SerializeField] private float maxFrequencyTime = 2f;
    
    
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    
        // Start is called before the first frame update
        void Start()
        {
            Invoke(nameof(CreateCollidableObject), 0f);
        }
    
    
        void CreateCollidableObject()
        {
            var y = Random.Range(bottomLimit.position.y, topLimit.position.y);
            Instantiate(collidableObjectPrefab, new Vector3(topLimit.position.x, y, 0), Quaternion.identity);
            float timeToNextCollidableObject = Random.Range(minFrequencyTime, maxFrequencyTime);
            Invoke(nameof(CreateCollidableObject), timeToNextCollidableObject);
        }
    
        /// <summary>
        /// Returns the Y value of the Top Limit
        /// </summary>
        /// <returns>The y value of the top limit</returns>
        public float GetTopLimitY()
        {
            return topLimit.position.y;
        }
    
        /// <summary>
        /// Return the Y value of the bottom limit
        /// </summary>
        /// <returns>the y value of the bottom limit</returns>
        public float GetBottomLimitY()
        {
            return bottomLimit.position.y;
        }
    
        /// <summary>
        /// Stops the spawning of collidable objects
        /// </summary>
        public void StopSpawning()
        {
            Instance.CancelInvoke(nameof(CreateCollidableObject));
        }
    }

}

