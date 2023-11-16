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
    public TargetManager TargetManager;
    public MenuUI MenuUI;
    public Timer Timer;

    private void Start()
    {
        state = GameState.MENU;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == GameState.MENU || state == GameState.FINISH)
        {
            return;
        }

        // else GameState.Start
        if (Input.GetMouseButtonDown(0))
        {
            // convert the mouse position to world point, adding new Vector3(0, 0, 10); the distance of the camera in z axis
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);

            // Check if the mouse position overlaps any collider, null if none, and the lowest z values if more than one
            var collider = Physics2D.OverlapPoint(mousePos);

            if (collider != null)
            {
                if (collider.CompareTag(TARGET_TAG))
                {
                    TargetManager.RemoveTarget(collider.gameObject);
                    GameScore.IncreaseScore(CLICK_POINT_VALUE);
                }

            }
        }
    }


    public void EndGame()
    {
        state = GameState.FINISH;
        int gameScore = GameScore.GetScore();
        int highScore = GameScore.CheckHighScore();
        MenuUI.ShowHighScorePanel(gameScore, highScore, false);

    }

    public void StartGame()
    {
        state = GameState.STARTED;
        TargetManager.StartTargetSpawning();
        Timer.StartTimer();
        GameScore.ResetScore();
    }
}

enum GameState
{
    MENU, STARTED, FINISH
}
