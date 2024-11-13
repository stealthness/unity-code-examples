using UnityEngine;
using UnityEngine.Events;

namespace _Scripts.MenuUI
{
    /// <summary>
    /// NextLevelMenuUI class is responsible for showing the next level panel and handling the next level and replay
    /// level button click events.
    /// </summary>
    public class NextLevelMenuUI : MonoBehaviour
    {
        public GameObject NextLevelPanel;
        public UnityEvent OnNextLevelClicked;
        public UnityEvent OnReplayLevelClicked;
        public UnityEvent OnBackToStartMenuClicked;
        public UnityEvent OnBackToPreviousLevelClicked;
        
        /// <summary>
        /// SHows the Next Level Menu
        /// </summary>
        public void ShowNextLevelMenu()
        {
            Debug.Log("Show Next Level Menu");
            NextLevelPanel.gameObject.SetActive(true);
        }
        
        /// <summary>
        /// Invokes the OnNextLevelClicked event
        /// </summary>
        public void OnNextLevel()
        {
            Debug.Log("Next Level Clicked");
            OnNextLevelClicked?.Invoke();
            NextLevelPanel.gameObject.SetActive(false);
        }
        
        /// <summary>
        /// Invokes the OnReplayLevelClicked event
        /// </summary>
        public void OnReplayLevel()
        {
            Debug.Log("Replay Level Clicked");
            OnReplayLevelClicked?.Invoke();
            NextLevelPanel.gameObject.SetActive(false);
        }
        
        /// <summary>
        /// Invokes the OnBackToStartMenuClicked event
        /// </summary>
        public void OnBackToStartMenu()
        {
            Debug.Log("Back to Start Menu Clicked");
            OnBackToStartMenuClicked?.Invoke();
            NextLevelPanel.gameObject.SetActive(false);
        }
        
        /// <summary>
        /// Invokes the OnBackToPreviousLevelClicked event
        /// </summary>
        public void OnBackToPreviousLevel()
        {
            Debug.Log("Back to Previous Level Clicked");
            OnBackToPreviousLevelClicked?.Invoke();
            NextLevelPanel.gameObject.SetActive(false);
        }
    }
}