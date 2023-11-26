using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform Target;
    public Vector3 Offset;


    private void Update()
    {
        transform.position = Offset + Target.position;
    }
}
