using System;
using _Scripts;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    private readonly int CLICK_POINT_VALUE = 1;
    private readonly string TARGET_TAG = "Target";
    private GameState state;

    public Score GameScore;
    public MenuUI MenuUI;
    public Timer Timer;
    public AudioSource TargetHitAudioSource;
    public AudioSource endGameSound;

    public static GameManager Instance;


    private void Awake()
    {
        if (Instance != null) {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        
    }

    private void Start()
    {
        state = GameState.Menu;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == GameState.Menu || state == GameState.Finish)
        {
            return;
        }
        //
        // // else GameState.Start
        // if (Input.GetMouseButtonDown(0))
        // {
        //     // convert the mouse position to world point, adding new Vector3(0, 0, 10); the distance of the camera in z axis
        //     var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);
        //
        //     // Check if the mouse position overlaps any collider, null if none, and the lowest z values if more than one
        //     var collider = Physics2D.OverlapPoint(mousePos);
        //
        //     if (collider != null)
        //     {
        //         if (collider.CompareTag(TARGET_TAG))
        //         {
        //             TargetHitAudioSource.Play();
        //             TargetManager.Instance.RemoveTarget(collider.gameObject);
        //             GameScore.IncreaseScore(CLICK_POINT_VALUE);
        //         }
        //
        //     }
        //}
    }


    
    
    public void OnTargetHit(GameObject target)
    {
        TargetHitAudioSource.Play();
        TargetManager.Instance.RemoveTarget(target);
        GameScore.IncreaseScore(CLICK_POINT_VALUE);
    }


    public void EndGame()
    {
        endGameSound.Play();
        state = GameState.Finish;
        int gameScore = GameScore.GetScore();
        int highScore = GameScore.CheckHighScore;
        MenuUI.ShowHighScorePanel(gameScore, highScore, GameScore.isNewHighScore);

    }

    public void StartGame()
    {
        state = GameState.Started;
        TargetManager.Instance.StartTargetSpawning();
        Timer.StartTimer();
        GameScore.ResetScore();
    }
}

enum GameState
{
    Menu, Started, Finish
}
