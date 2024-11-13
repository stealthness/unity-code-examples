using UnityEngine;
using UnityEngine.Events;

namespace _Scripts.MenuUI
{
    
    
    public class OptionsMenuUI : MonoBehaviour
    {
        public GameObject OptionsPanel;
        
        public UnityEvent OnBackClicked;
        //public UnityEvent<bool> OnSoundToggled;
        public UnityEvent<bool> OnMusicToggled;
        //public UnityEvent<float> OnSensitiveChanged;
        
        public void ShowOptionsMenu()
        {
            Debug.Log("Show Options Menu");
            OptionsPanel.gameObject.SetActive(true);
        }
        
        public void OnBack()
        {
            Debug.Log("Back Clicked");
            OnBackClicked?.Invoke();
            OptionsPanel.gameObject.SetActive(false);
        }

        public void OnMusic(bool toggle)
        {
            OnMusicToggled?.Invoke(toggle);
            if (toggle)
            {
                Debug.Log("Music On");
            }
            else
            {
                Debug.Log("Music Off");
            }
        }
        
    }
}