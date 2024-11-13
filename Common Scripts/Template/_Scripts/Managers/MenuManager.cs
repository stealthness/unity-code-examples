using UnityEngine;

namespace _Scripts.Managers
{
    public class MenuManager : MonoBehaviour
    {
        
        public GameObject startMenu;
        
        public static MenuManager Instance;

        private void Awake()
        {
            if(MenuManager.Instance == null)
            {
                MenuManager.Instance = this;
            }
            else
            {
                Destroy(gameObject);
                DontDestroyOnLoad(this);
            }
        }
        
        public void OnStartGame()
        {
            Debug.Log("MM: Start Started Clicked");
        }
        
        public void OnExitGame()
        {
            Debug.Log("MM: Exit Game Clicked");
        }
        
        public void OnOptions()
        {
            Debug.Log("MM: Options Clicked");
        }
        
        public void OnCredits()
        {
            Debug.Log("MM: Credits Clicked");
        }
        
        public void OnBack()
        {
            Debug.Log("MM: Back Clicked");
        }
        
        public void OnNext()
        {
            Debug.Log("MM: Next Clicked");
        }
        
    }
}
