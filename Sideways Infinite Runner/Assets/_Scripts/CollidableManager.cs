using UnityEngine;
using Random = UnityEngine.Random;

namespace _Scripts
{
    public class CollidableManager : MonoBehaviour
    {
        public static CollidableManager Instance { get; private set; }
    
        public Transform topLimit;
        public Transform bottomLimit;
        public GameObject minePrefab;
        public GameObject coinPrefab;
    
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
            Invoke(nameof(CreateMine), 0f);
            Invoke(nameof(CreateCoin), 1f);
        }

        private float GetRandomYValue()
        {
            return Random.Range(bottomLimit.position.y, topLimit.position.y);
        }

        private void CreateCoin()
        {
            Instantiate(coinPrefab, new Vector3(topLimit.position.x, GetRandomYValue(), 0), Quaternion.identity);
            float timeToNextCollidableObject = Random.Range(minFrequencyTime, maxFrequencyTime);
            Invoke(nameof(CreateCoin), timeToNextCollidableObject);
        }
    
        private void CreateMine()
        {
            Instantiate(minePrefab, new Vector3(topLimit.position.x, GetRandomYValue(), 0), Quaternion.identity);
            float timeToNextCollidableObject = Random.Range(minFrequencyTime, maxFrequencyTime);
            Invoke(nameof(CreateMine), timeToNextCollidableObject);
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
            CancelInvoke(nameof(CreateMine));
            CancelInvoke(nameof(CreateCoin));
        }
    }

}

