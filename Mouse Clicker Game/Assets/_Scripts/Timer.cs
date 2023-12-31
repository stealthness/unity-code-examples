using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private const int GAME_TIME_LENGTH = 60;
    private int gameTimer;

    public TextMeshProUGUI TimerText;

    // Start is called before the first frame update
    void Start()
    {
        ResetTimer();
    }

    /// <summary>
    /// Starts the timer
    /// </summary>
    public void StartTimer()
    {
        ResetTimer();
        InvokeRepeating("NextSec", 1f, 1f);
    }

    private void NextSec()
    {

        if (gameTimer <= 0)
        {
            CancelInvoke();
            FindObjectOfType<TargetManager>().CancelTargetSpawn();
            GameManager.Instance.EndGame();
        }
        else
        {
            gameTimer--;
            TimerText.text = $"{gameTimer}";
        }

    }

    /// <summary>
    /// Resets the timer
    /// </summary>
    public void ResetTimer()
    {
        gameTimer = GAME_TIME_LENGTH;
        TimerText.text = $"{gameTimer}";
    }
}
