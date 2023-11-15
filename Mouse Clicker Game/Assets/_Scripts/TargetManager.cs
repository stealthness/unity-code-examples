using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the spawing of target clones
/// </summary>
public class TargetManager : MonoBehaviour
{

    private const int MinInclusive = -4;
    private const int MaxExclusive = 4;
    private const float FirstSpawnTime = 0f;
    private const float RepeatSpawnRate = 0.5f;

    public GameObject TargetPrefab;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateTarget", FirstSpawnTime, RepeatSpawnRate);
    }


    /// <summary>
    /// Create a new Target a a Random location
    /// </summary>
    void CreateTarget()
    {
        Instantiate(TargetPrefab, GetRandomPosition(), Quaternion.identity);
    }

    /// <summary>
    /// Returns a random position for target to be created at
    /// </summary>
    /// <returns>a random vector</returns>
    private static Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(MinInclusive, MaxExclusive), Random.Range(MinInclusive, MaxExclusive), 0f);
    }

    /// <summary>
    /// Cancels the spawning of targets
    /// </summary>
    public void CancelTargetSpawn()
    {
        CancelInvoke();
    }
}
