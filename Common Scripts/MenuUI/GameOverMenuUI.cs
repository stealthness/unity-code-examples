using UnityEngine;
using UnityEngine.Events;

namespace _Scripts.MenuUI
{
    /// <summary>
    /// The GameOverMenuUI class is responsible for showing the game over panel and handling the replay level and back
    /// to start menu button click events.
    /// </summary>
    public class GameOverMenuUI : MonoBehaviour
    {
        public GameObject GameOverPanel;
        public UnityEvent OnReplayLevelClicked;
        public UnityEvent OnBackToStartMenuClicked;
        
        /// <summary>
        /// Show the Game Over Menu
        /// </summary>
        public void ShowGameOverMenu()
        {
            Debug.Log("Show Game Over Menu");
            GameOverPanel.gameObject.SetActive(true);
        }
        
        /// <summary>
        /// Invokes the OnReplayLevelClicked event
        /// </summary>
        public void OnReplayLevel()
        {
            Debug.Log("Replay Level Clicked");
            OnReplayLevelClicked?.Invoke();
            GameOverPanel.gameObject.SetActive(false);
        }
        
        /// <summary>
        /// Inkoves the OnBackToStartMenuClicked event
        /// </summary>
        public void OnBackToStartMenu()
        {
            Debug.Log("Back to Start Menu Clicked");
            OnBackToStartMenuClicked?.Invoke();
            GameOverPanel.gameObject.SetActive(false);
        }
        
    }
}