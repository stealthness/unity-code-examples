using UnityEngine;


public class CollidableManager : MonoBehaviour
{


    public Transform topLimit;
    public Transform bottomLimit;
    public GameObject CollidableObjectPrefab;

    [SerializeField] private float minFrequencyTime = 0.1f;
    [SerializeField] private float maxFrequencyTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("CreateCollidableObject", 0f);
    }


    void CreateCollidableObject()
    {
        var y = Random.Range(bottomLimit.position.y, topLimit.position.y);
        Instantiate(CollidableObjectPrefab, new Vector3(topLimit.position.x, y, 0), Quaternion.identity);
        float timeToNextCollidableObject = Random.Range(minFrequencyTime, maxFrequencyTime);
        Invoke("CreateCollidableObject", timeToNextCollidableObject);
    }
}
