using TMPro;
using UnityEngine;

/// <summary>
/// The Script controls the the game's UI
/// </summary>
public class MenuUI : MonoBehaviour
{

    public GameObject HighScoreGamePanel;
    public GameObject StartMenuGamePanel;

    public TextMeshProUGUI LastGameScoreText;
    public TextMeshProUGUI HighScoreText;
    public TextMeshProUGUI NewHighScoreRecordText;
    public AudioSource clickButtonAudio;
    private readonly float END_GAME_DELAY = 2f;


    // Start is called before the first frame update
    void Start()
    {
        StartMenuGamePanel.gameObject.SetActive(true);
        HighScoreGamePanel.gameObject.SetActive(false);
    }

    /// <summary>
    ///  Called when the StartGameButton is clicked on the menu game panel
    /// </summary>
    public void StartGameButtonClicked()
    {
        clickButtonAudio.Play();
        StartMenuGamePanel.gameObject.SetActive(false);
        GameManager.Instance.StartGame();
    }

    /// <summary>
    /// Called when the Contineue Button is clicked on theend game panel
    /// </summary>
    public void ContinueButtonClicked()
    {
        clickButtonAudio.Play();
        HighScoreGamePanel.SetActive(false);
        StartMenuGamePanel.SetActive(true);
    }

    /// <summary>
    /// Show the high score panel with current game score, high score, and if there is new record high score
    /// </summary>
    /// <param name="score"></param> the current game's score
    /// <param name="highScore"></param> the current best game highscore
    /// <param name="isNewHighScore"></param> true if there is a new record, false otherwise
    public void ShowHighScorePanel(int score, int highScore, bool isNewHighScore)
    {

        NewHighScoreRecordText.gameObject.SetActive(isNewHighScore);
        HighScoreText.text = $"{highScore}";
        LastGameScoreText.text = $"{score}";
        Invoke("ShowHighScorePanelDelay", END_GAME_DELAY);
    }

    private void ShowHighScorePanelDelay()
    {
        HighScoreGamePanel.gameObject.SetActive(true);
    }
}
