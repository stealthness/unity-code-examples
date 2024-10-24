using UnityEngine;

namespace _Scripts
{
    public class PillarManager : MonoBehaviour
    {
    
        public GameObject PillarPrefab;
        public Transform BottomPillarStartPoint;
        public Transform TopPillarStartPoint;
        [SerializeField] private float startFirstPillarTime = 0f;
        [SerializeField] private float repeatNextPillarTime = 2f;
        [SerializeField] private float pillarSpeed = 3f;
        [SerializeField] private float gapHeight = 1f;
    
        // Start is called before the first frame update
        void Start()
        {
            Invoke(nameof(CreatePillars), startFirstPillarTime);
        }
    
        private void CreatePillars()
        {
            Debug.Log("Pillars Create");
            var length = TopPillarStartPoint.position.y - BottomPillarStartPoint.position.y;
            var bottomHeight = Random.Range(1, 4);
            var topHeight = length - gapHeight - bottomHeight;
            CreatePillarColumnAt(BottomPillarStartPoint.position, bottomHeight);
            CreatePillarColumnAt(TopPillarStartPoint.position, topHeight);
            Invoke(nameof(CreatePillars), repeatNextPillarTime);
        }
    
        private void CreatePillarColumnAt(Vector3 position, float height)
        {
            var pillar = Instantiate(PillarPrefab, position, Quaternion.identity);
            pillar.GetComponent<Pillar>().PillarSpeed = pillarSpeed;
            pillar.transform.Translate(new Vector3(0f, height, 0f));
    
        }
    }

}

