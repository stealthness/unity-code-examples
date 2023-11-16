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

    private List<GameObject> targets = new();

    public GameObject TargetPrefab;
    
    /// <summary>
    /// Create a new Target a a Random location
    /// </summary>
    void CreateTarget()
    {
        var target = Instantiate(TargetPrefab, GetRandomPosition(), Quaternion.identity);
        targets.Add(target);
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

    public void StartTargetSpawning()
    {
        DestoyAllTargets();
        InvokeRepeating("CreateTarget", FirstSpawnTime, RepeatSpawnRate);
    }

    private void DestoyAllTargets()
    {
        targets.ForEach(target =>
        {
            if (target != null)
            {
                target.SetActive(false);
                Destroy(target);
            }

        });
        targets.Clear();
    }

    public void RemoveTarget(GameObject target)
    {
        targets.Remove(target);
        Destroy(target);
    }
}
