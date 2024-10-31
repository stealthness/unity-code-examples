using UnityEngine;

namespace _Scripts.Core
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform Target;
        [SerializeField] private float smoothSpeed = 0.125f;
        [SerializeField] private Vector3 offset = new Vector3(0, 0, -10f);

        private void LateUpdate()
        {
            var desiredPosition = Target.position + offset;
            var smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
