using UnityEngine;

namespace _Scripts
{
    /// <summary>
    /// This is a generic GameManager class that can be used in any game.
    /// </summary>
    public class GameManager : MonoBehaviour
    {

        public static GameManager Instance;
        
        [SerializeField] private bool activateStartMenuOnStart = true;

        private void Awake()
        {
            if(GameManager.Instance == null)
            {
                GameManager.Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// Start is called before the first frame update, freezes the game if activateStartMenuOnStart is false
        /// </summary>
        void Start()
        {
            Time.timeScale = 0;
            if (!activateStartMenuOnStart)
            {
                StartGame();
            }
        }

        /// <summary>
        /// Starts the game
        /// </summary>
        private void StartGame()
        {
            Time.timeScale = 1;
        }
        
        /// <summary>
        /// OnRestartGame is called when the player wants to restart the game
        /// </summary>
        public void OnRestartGame()
        {
            Time.timeScale = 1;
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        
    }
}
