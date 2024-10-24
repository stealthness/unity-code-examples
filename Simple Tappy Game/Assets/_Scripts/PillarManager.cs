using UnityEngine;

namespace _Scripts
{
    public class PillarManager : MonoBehaviour
    {
    
        public GameObject PillarPrefab;
        [SerializeField] private float startFirstPillarTime = 1f;
        [SerializeField] private float repeatNextPillarTime = 2f;
        [SerializeField] private float pillarSpeed = 3f;
        [SerializeField] private float gapHeight = 2f;
    
        // Start is called before the first frame update
        void Start()
        {
            Invoke(nameof(CreatePillars), startFirstPillarTime);
        }
    
        private void CreatePillars()
        {
            Debug.Log("Pillars Create");
            var pillar = Instantiate(PillarPrefab);
            pillar.GetComponent<Rigidbody2D>().linearVelocityX = -pillarSpeed;
            pillar.transform.position = new Vector3(5, Random.Range(-gapHeight, gapHeight), 0);
            Invoke(nameof(CreatePillars), repeatNextPillarTime);
        }
    

    }

}

