using System;
using TMPro;
using UnityEngine;

/// <summary>
/// The Script controls the the game's UI
/// </summary>
public class MenuUI : MonoBehaviour
{

    public GameObject EndGamePanel;
    public GameObject StartGamePanel;
    public GameManager GameManager;

    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI newHighScoreText;
    private readonly float END_GAME_DELAY = 2f;


    // Start is called before the first frame update
    void Start()
    {
        StartGamePanel.gameObject.SetActive(true);
        EndGamePanel.gameObject.SetActive(false);
    }


    public void StartGame()
    {
        GameManager.StartGame();
        StartGamePanel.gameObject.SetActive(false);
    }

    public void EndGame(int score, int highScore, bool isNewHighScore)
    {
        if (isNewHighScore)
        {
            newHighScoreText.gameObject.SetActive(true);
            highScoreText.text = $"{score}";
        }
        else
        {
            newHighScoreText.gameObject.SetActive(false);
            highScoreText.text = $"{score}";
        }
        Invoke("EndGameDelay", END_GAME_DELAY);
    }

    public void Continue()
    {
        EndGamePanel.SetActive(false);
        StartGamePanel.SetActive(true);
    }

    public void EndGameDelay()
    {
        EndGamePanel.gameObject.SetActive(true);
    }
}
