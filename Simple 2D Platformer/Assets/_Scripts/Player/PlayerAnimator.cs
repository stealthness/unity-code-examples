using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        private readonly Dictionary<string, AnimationClip> _playerAnimations = new();
        private const string PlayerAnimationsPath = "Animations/Player/";

        // Load animation clip and cache it in the dictionary
        public IEnumerator LoadPlayerAnimation(string name)
        {
            if (_playerAnimations.ContainsKey(name))
            {
                Debug.Log($"Animation {name} is already loaded.");
                yield break; // Already loaded, no need to load again
            }

            // Simulate loading with Resources.Load or Asset Bundles (in a real case, use proper loading logic)
            var request = Resources.LoadAsync<AnimationClip>(PlayerAnimationsPath);

            yield return request;

            if (request.asset != null)
            {
                AnimationClip clip = (AnimationClip)request.asset;
                _playerAnimations.Add(name, clip);
                Debug.Log($"Animation {name} loaded successfully.");
            }
            else
            {
                Debug.LogError($"Failed to load animation {name} from {PlayerAnimationsPath}.");
            }
        }

        public AnimationClip GetAnimation(string name)
        {
            if (_playerAnimations.ContainsKey(name))
            {
                return _playerAnimations[name];
            }

            Debug.LogError($"Animation {name} not found.");
            return null;
        }
    }
}