using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private readonly int CLICK_POINT_VALUE = 1;
    private readonly string TARGET_TAG = "Target";
    private GameState state;

    /// <summary>
    /// Reference to Score script to update the game's score
    /// </summary> 
    public Score GameScore;

    private void Start()
    {
        state = GameState.STARTED;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == GameState.MENU || state == GameState.FINISH)
        {
            return;
        }


        if (Input.GetMouseButtonDown(0))
        {
            // convert the mouse position to world point, adding new Vector3(0, 0, 10); the distance of the camera in z axis
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);

            // Check if the mouse position overlaps any collider, null if none, and the lowest z values if more than one
            var collider = Physics2D.OverlapPoint(mousePos);

            if (collider != null)
            {
                Debug.Log($"hit {collider.name}");
                if (collider.CompareTag(TARGET_TAG))
                {
                    Destroy(collider.gameObject);
                    GameScore.IncreaseScore(CLICK_POINT_VALUE);
                }

            }
        }
    }
}

enum GameState
{
    MENU, STARTED, FINISH
}
