using TMPro;
using UnityEngine;

/// <summary>
/// The Script controls the the game's UI
/// </summary>
public class MenuUI : MonoBehaviour
{

    public GameObject HighScoreGamePanel;
    public GameObject StartMenuGamePanel;
    public GameManager GameManager;

    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI newHighScoreText;
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
        StartMenuGamePanel.gameObject.SetActive(false);
        GameManager.StartGame();
    }


    public void ShowHighScorePanel(int score, int highScore, bool isNewHighScore)
    {

        newHighScoreText.gameObject.SetActive(isNewHighScore);
        highScoreText.text = $"{highScore}";
        Invoke("ShowHighScorePanelDelay", END_GAME_DELAY);
    }

    /// <summary>
    /// Called when the Contineue Button is clicked on theend game panel
    /// </summary>
    public void ContinueButtonClicked()
    {
        HighScoreGamePanel.SetActive(false);
        StartMenuGamePanel.SetActive(true);
    }

    public void ShowHighScorePanelDelay()
    {
        HighScoreGamePanel.gameObject.SetActive(true);
    }
}
