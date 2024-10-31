using UnityEngine;

namespace _Scripts.Core
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform Target;
        [SerializeField] private float smoothSpeed = 0.125f;
        [SerializeField] private Vector3 offset = new Vector3(0, 0, -10f);
        private bool _stopFollowing;

        private void LateUpdate()
        {
            if (_stopFollowing) return;
            
            var desiredPosition = Target.position + offset;
            var smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
        
        public void SetTarget(Transform target)
        {
            Target = target;
        }
        
        public void StopFollowing()
        {
            _stopFollowing = true;
        }
    }
}
