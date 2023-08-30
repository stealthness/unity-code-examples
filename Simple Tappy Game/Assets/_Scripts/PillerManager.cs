using UnityEngine;


public class PillerManager : MonoBehaviour
{

    public GameObject PillerPrefab;
    public Transform BottomPillerStartPoint;
    public Transform TopPillerStartPoint;
    [SerializeField] private float startFirstPillerTime = 0f;
    [SerializeField] private float repeatNextPillerTime = 2f;
    [SerializeField] private float pillerSpeed = 3f;
    [SerializeField] private float gapHeight = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("CreatePiller", startFirstPillerTime);
    }

    private void CreatePiller()
    {
        Debug.Log("Pillers Create");
        float length = TopPillerStartPoint.position.y - BottomPillerStartPoint.position.y;
        float bottomHeight = Random.Range(1, length - gapHeight - 1);
        float topHeight = length - gapHeight - bottomHeight;
        CreatePillerAt(BottomPillerStartPoint.position, bottomHeight);
        CreatePillerAt(TopPillerStartPoint.position, topHeight);
        Invoke("CreatePiller", repeatNextPillerTime);
    }

    private void CreatePillerAt(Vector3 position, float height)
    {
        var piller = Instantiate(PillerPrefab, position, Quaternion.identity);
        piller.GetComponent<Piller>().pillerSpeed = pillerSpeed;
        piller.GetComponent<Piller>().pillerHeight = height;

    }

}
