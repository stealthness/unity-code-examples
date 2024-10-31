using UnityEngine;

namespace _Scripts.Core
{
    /// <summary>
    /// Destroys objects that leave the game area
    /// </summary>
    public class GameAreaCheck : MonoBehaviour
    {
        private void OnTriggerExit(Collider other)
        {
            Destroy(other.gameObject);
        }
    }
}
