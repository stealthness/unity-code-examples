using UnityEngine;

namespace _Scripts.Managers
{
    public class EnemyManager : MonoBehaviour
    {
     
        public static EnemyManager Instance;
        public GameObject EnemyPrefab;
        public Transform target;
        
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
        
        
        private void Start()
        {
            InvokeRepeating(nameof(GenerateEnemy), 1, 1);
        }
        
        private void GenerateEnemy()
        {
            Instantiate(EnemyPrefab, validPostion(), Quaternion.identity);
        }

        private Vector3 validPostion()
        {
            Vector3 position = Vector3.zero;
            bool notValid = true;
            while (notValid)
            {
                position = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0);
                if (Vector3.Distance(position, target.position) > 5)
                {
                    notValid = false;
                }
            }
            return position;
        }

        public Vector3 GetTarget()
        {
            return target.position;
        }
    }
}