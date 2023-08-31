using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{

    public GameObject TargetPrefab;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateTarget()
    {
        Vector3 randomPos = new Vector3(Random.Range(-4, 4), Random.Range(-4, 4), 0f);
        Instantiate(TargetPrefab, randomPos, Quaternion.identity);
    }
}
