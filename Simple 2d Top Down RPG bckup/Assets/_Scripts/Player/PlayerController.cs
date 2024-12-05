using UnityEngine;

public class PlayerController : MonoBehaviour
{
    internal static readonly string Tag = "Player";
    private readonly float TOL = 0.01f;
    private PlayerState playerState = PlayerState.Playable;

    public Vector2 MoveDir { get; private set;}


    // Update is called once per frame
    void Update()
    {

        if (playerState == PlayerState.Disabled)
        {
            MoveDir = Vector2.zero;
            return;
        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        MoveDir = new Vector2(x, y);
        if (MoveDir.magnitude > TOL)
        {
            MoveDir = MoveDir.normalized;
        }
        else
        {
            MoveDir = Vector2.zero;
        }
    }

    public void DiasablePlayer()
    {
        playerState = PlayerState.Disabled;
    }
}

enum PlayerState
{
    Playable, Disabled
}
