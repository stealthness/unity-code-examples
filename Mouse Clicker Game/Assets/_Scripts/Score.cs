using TMPro;
using UnityEngine;

/// <summary>
/// This class keeps a track of the game's score
/// </summary>
public class Score : MonoBehaviour
{
    private int gameScore;
    /// <summary>
    /// Reference to a game's UI score text
    /// </summary>
    public TextMeshProUGUI GameScoreText;

    private void Start()
    {
        gameScore = 0;
    }


    /// <summary>
    /// Increases the the game's score by a non-negative amount, and updates the game's UI score
    /// </summary>
    /// <param name="amount"> the amount the score will increase by, assumend that it will be non-negative</param>
    public void IncreaseScore(int amount)
    {
        gameScore += amount;
        GameScoreText.text = $"{gameScore}";
    }

    /// <summary>
    /// Reset the the game's score to zero
    /// </summary>
    public void ResetScore()
    {
        gameScore = 0;
    }
}