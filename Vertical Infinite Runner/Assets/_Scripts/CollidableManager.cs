using UnityEngine;


public class CollidableManager : MonoBehaviour
{
    public Transform leftLimit;
    public Transform rightLimit;
    public GameObject CollidableObjectPrefab;

    [SerializeField] private float minFrequencyTime;
    [SerializeField] private float maxFrequencyTime;

    public static CollidableManager Instance;
    private readonly float percentageDecreaseMaxFrequency = 0.99f;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }
        Instance = this;
    }


    private void CreateCollidableObject()
    {
        var x = Random.Range(leftLimit.position.x, rightLimit.position.x);
        var y = leftLimit.position.y;
        Instantiate(CollidableObjectPrefab, new Vector3(x, y, 0), Quaternion.identity);
        float timeToNextCollidableObject = Random.Range(minFrequencyTime, maxFrequencyTime);
        maxFrequencyTime = Mathf.Max(minFrequencyTime, maxFrequencyTime * percentageDecreaseMaxFrequency);
        Invoke(nameof(CreateCollidableObject), timeToNextCollidableObject);
    }

    /// <summary>
    /// Starts Spawning Collidable objects
    /// </summary>
    public void StartSpawningCollidableObjects(float minFrequencyTime, float maxFrequencyTime)
    {
        this.maxFrequencyTime = maxFrequencyTime;
        this.minFrequencyTime = minFrequencyTime;
        Invoke(nameof(CreateCollidableObject), 0f);
    }
}
