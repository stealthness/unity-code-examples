using UnityEngine;
using UnityEngine.Events;

namespace _Scripts.MenuUI
{
    /// <summary>
    /// The CreditsMenuUI class is responsible for showing the credits panel and handling the back button click event.
    /// </summary>
    public class CreditsMenuUI : MonoBehaviour
    {
        public GameObject CreditsPanel;
        public UnityEvent OnBackClicked;
        
        /// <summary>
        /// Shows the Credits Menu
        /// </summary>
        public void ShowCreditsMenu()
        {
            Debug.Log("Show Credits Menu");
            CreditsPanel.gameObject.SetActive(true);
        }
        
        /// <summary>
        /// Invokes the OnBackClicked event
        /// </summary>
        public void OnBack()
        {
            Debug.Log("Back Clicked");
            OnBackClicked?.Invoke();
            CreditsPanel.gameObject.SetActive(false);
        }
        
    }
}
