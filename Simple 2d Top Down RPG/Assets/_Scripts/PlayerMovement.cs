using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : Movement
{

    PlayerController playerController;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        speed = 5f;
    }

    private void Update()
    {
        if (playerController.MoveDir != Vector2.zero) 
        {
            MoveDir(playerController.MoveDir);
        }
    }


}
