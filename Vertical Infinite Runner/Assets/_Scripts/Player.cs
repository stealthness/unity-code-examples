using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{


    public Transform leftLimit;
    public Transform rightLimit;
    [SerializeField] private float playerSpeed = 5f;


    private void Update()
    {
        var x = Input.GetAxis("Horizontal");
        if (x > 0 && transform.position.x < rightLimit.position.x)
        {
            transform.Translate(playerSpeed * x * Time.deltaTime * Vector3.right);
        }
        if (x < 0 && transform.position.x > leftLimit.position.x)
        {
            transform.Translate(playerSpeed * x * Time.deltaTime * Vector3.right);
        }


    }


}
