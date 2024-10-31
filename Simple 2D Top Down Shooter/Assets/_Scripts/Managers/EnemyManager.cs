using _Scripts.Core;
    
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.Managers
{
    /// <summary>
    /// EnemyManager is a singleton class that manages the generation of enemies.   
    /// </summary>
    public class EnemyManager : MonoBehaviour
    {
     
        [FormerlySerializedAs("Score")] public ScoreManager scoreManager;
        public static EnemyManager Instance;
        /// <summary>
        /// List of the enemy prefabs
        /// </summary>
        public GameObject[] enemyPrefab;
        /// <summary>
        /// The target of the enemies
        /// </summary>
        public Transform target;
        /// <summary>
        /// The frequency of generating enemies
        /// </summary>
        [SerializeField] private float generateEnemyFrequency = 1f;
        
        [SerializeField] private float maxDistanceFromTargetToSpawn = 15f;
        [SerializeField] private float minDistanceFromTargetToSpawn = 5f;

        /// <summary>
        /// Awake method to make sure that there is only one instance of the class
        /// </summary>
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
        
        /// <summary>
        /// Start method to start generating enemies
        /// </summary>
        private void Start()
        {
            InvokeRepeating(nameof(GenerateEnemy), 0, generateEnemyFrequency);
        }
        
        /// <summary>
        /// Generate enemy method to generate enemies at random positions
        /// </summary>
        private void GenerateEnemy()
        {
            Instantiate(enemyPrefab[0], ValidPostion(), Quaternion.identity);
            Instantiate(enemyPrefab[1], ValidPostion(), Quaternion.identity);
        }

        /// <summary>
        /// Method to get a valid position for the enemy, prevents the enemy from spawning near the target
        /// </summary>
        private Vector3 ValidPostion()
        {
            var randomStartPosition = Vector3.zero;
            var notValid = true;
            while (notValid)
            {
                // get a random position
                var rx = Random.Range(-maxDistanceFromTargetToSpawn, maxDistanceFromTargetToSpawn);
                var ry = Random.Range(-maxDistanceFromTargetToSpawn, maxDistanceFromTargetToSpawn);
                randomStartPosition = new Vector3(rx, ry, 0);
                // check if the distance between the target and the random position is greater than the minimum distance
                if (Vector3.Distance(randomStartPosition, target.position) > minDistanceFromTargetToSpawn)
                {
                    notValid = false;
                }
            }
            return randomStartPosition;
        }
        
        /// <summary>
        /// Method to get the target of the enemies
        /// </summary>
        public Vector3 GetTarget()
        {
            if (target == null)
            {
                return Vector3.zero;
            }
            return target.position;
        }
    }
}