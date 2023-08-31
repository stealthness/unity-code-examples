using UnityEngine;


public class CollidableManager : MonoBehaviour
{


    public Transform leftLimit;
    public Transform rightLimit;
    public GameObject CollidableObjectPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("CreateCollidableObject", 0f);
    }


    void CreateCollidableObject()
    {
        Instantiate(CollidableObjectPrefab, new Vector3(0, 10, 0), Quaternion.identity);
        Invoke("CreateCollidableObject", 5f);
    }
}
