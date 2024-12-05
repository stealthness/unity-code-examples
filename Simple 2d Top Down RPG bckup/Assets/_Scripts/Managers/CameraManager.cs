using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform Target;
    public Vector3 Offset;
    [SerializeField] private float CamMoveSpeed = 5f;

    /// <summary>
    /// Late Update to avoid desync issues
    /// </summary>
    private void LateUpdate()
    {
        //transform.position = Offset + Target.position;
        transform.position = Vector3.Lerp(transform.position, Offset + Target.position,  CamMoveSpeed * Time.deltaTime);
    }
}
