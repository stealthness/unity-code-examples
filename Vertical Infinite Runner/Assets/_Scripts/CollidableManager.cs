using UnityEngine;


public class CollidableManager : MonoBehaviour
{


    public Transform leftLimit;
    public Transform rightLimit;
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
        var x = Random.Range(leftLimit.position.x, rightLimit.position.x);
        Instantiate(CollidableObjectPrefab, new Vector3(x, 10, 0), Quaternion.identity);
        float timeToNextCollidableObject = Random.Range(minFrequencyTime, maxFrequencyTime);
        Invoke("CreateCollidableObject", timeToNextCollidableObject);
    }
}
