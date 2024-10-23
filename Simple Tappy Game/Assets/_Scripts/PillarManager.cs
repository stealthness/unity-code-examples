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
        [SerializeField] private float gapHeight = 2f;
    
        // Start is called before the first frame update
        void Start()
        {
            Invoke("CreatePillar", startFirstPillarTime);
        }
    
        private void CreatePillar()
        {
            Debug.Log("Pillars Create");
            float length = TopPillarStartPoint.position.y - BottomPillarStartPoint.position.y;
            float bottomHeight = Random.Range(1, length - gapHeight - 1);
            float topHeight = length - gapHeight - bottomHeight;
            CreatePillarAt(BottomPillarStartPoint.position, bottomHeight);
            CreatePillarAt(TopPillarStartPoint.position, topHeight);
            Invoke("CreatePillar", repeatNextPillarTime);
        }
    
        private void CreatePillarAt(Vector3 position, float height)
        {
            var pillar = Instantiate(PillarPrefab, position, Quaternion.identity);
            pillar.GetComponent<Pillar>().PillarSpeed = pillarSpeed;
            pillar.GetComponent<Pillar>().PillarHeight = height;
    
        }
    
    }

}

