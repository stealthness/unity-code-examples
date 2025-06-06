using System.Collections.Generic;
using UnityEngine;

namespace _Scripts
{
    /// <summary>
    /// Manages the spawing of target clones
    /// </summary>
    public class TargetManager : MonoBehaviour
    {

        private const int MinInclusive = -4;
        private const int MaxExclusive = 4;
        private const float FirstSpawnTime = 0f;
        private const float RepeatSpawnRate = 0.5f;

        private readonly List<GameObject> _targets = new();

        public GameObject TargetPrefab;

        public static TargetManager Instance;

        public void Awake()
        {
            if (Instance != null)
            {
                Destroy(this);
            }
            Instance = this;
        }


        /// <summary>
        /// Create a new Target a a Random location
        /// </summary>
        void CreateTarget()
        {
            var target = Instantiate(TargetPrefab, GetRandomPosition(), Quaternion.identity);
            _targets.Add(target);
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
            InvokeRepeating(nameof(CreateTarget), FirstSpawnTime, RepeatSpawnRate);
        }

        private void DestoyAllTargets()
        {
            _targets.ForEach(target =>
            {
                if (target != null)
                {
                    target.SetActive(false);
                    Destroy(target);
                }

            });
            _targets.Clear();
        }

        public void RemoveTarget(GameObject target)
        {
            _targets.Remove(target);
            Destroy(target);
        }
    }
}
