using System;
using UnityEngine;

public class PlayerMovement : Movement
{

    private PlayerController playerController;
    private RaycastHit2D hit;
    [SerializeField] string[] layers = new string[] { "Blocking" };

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        speed = 5f;
    }

    private void Update()
    {
        Vector2 dir = playerController.MoveDir;
        if (playerController.MoveDir != Vector2.zero && CheckMove(dir)) 
        {
            MoveDir(dir);
        }
    }

    /// <summary>
    /// Checks collision using box cast
    /// Note: remember to change settings of Physics2D to uncheck "queires start in collider"
    /// </summary>
    /// <returns></returns>
    private bool CheckMove(Vector2 dir)
    {
        int layerMasks = LayerMask.GetMask(layers);
        if (Mathf.Abs(dir.y) > 0)
        {
            hit = Physics2D.BoxCast(transform.position, ((BoxCollider2D)box).size, 0, new Vector2(0, dir.y), Mathf.Abs(dir.y * Time.deltaTime * speed), layerMasks);
            if (hit.collider != null)
            {
                return false;
            }
        }
        
        if (Mathf.Abs(dir.x) > 0)
        {
            hit = Physics2D.BoxCast(transform.position, ((BoxCollider2D)box).size, 0, new Vector2(dir.x, 0), Mathf.Abs(dir.x * Time.deltaTime * speed), layerMasks);
            if (hit.collider != null)
            {
                return false;
            }
        }

        
        return true;
    }
}
