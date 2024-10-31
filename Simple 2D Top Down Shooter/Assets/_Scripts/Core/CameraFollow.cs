using UnityEngine;

namespace _Scripts.Core
{
    /// <summary>
    /// Camera follow script smooths out the camera follow of a target
    /// </summary>
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;
        [SerializeField] private float smoothSpeed = 0.125f;
        [SerializeField] private Vector3 offset = new(0, 0, -10f);
        private bool _stopFollowing;

        /// <summary>
        /// A smoothed out camera follow
        /// </summary>
        private void LateUpdate()
        {
            if (_stopFollowing) return;
            
            var desiredPosition = target.position + offset;
            var smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
        
        /// <summary>
        /// Sets a new target to follow
        /// </summary>
        public void SetTarget(Transform newTarget)
        {
            this.target = newTarget;
        }
        
        /// <summary>
        /// Stop following the target
        /// </summary>
        public void StopFollowing()
        {
            _stopFollowing = true;
        }
    }
}
