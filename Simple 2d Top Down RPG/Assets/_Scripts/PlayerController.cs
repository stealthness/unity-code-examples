using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public Vector2 MoveDir { get; private set;}


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        MoveDir = new Vector2(x, y);
        if (MoveDir.magnitude > 0.01f)
        {
            MoveDir = MoveDir.normalized;
        }
        else
        {
            MoveDir = Vector2.zero;
        }
    }

}
