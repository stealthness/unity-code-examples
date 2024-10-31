using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts.Managers
{

    /// <summary>
    /// GameManager class that is responsible for managing the game state
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        /// <summary>
        /// GameManager instance is a singleton that is accessed by other classes
        /// </summary>
        public static GameManager Instance;

        /// <summary>
        /// Awake is called when the script instance is being loaded and will set the GameManager instance to this object
        /// </summary>
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// OnPauseToggle is called when the pause button is pressed and will toggle the game between paused and resumed
        /// </summary>
        public void OnPauseToggle(InputAction.CallbackContext context)
        {
            if (!context.performed) return;

            if (Time.timeScale.Equals(0))
            {
                Debug.Log("Game Resumed");
                Time.timeScale = 1;
            }
            else
            {
                Debug.Log("Game Paused");
                Time.timeScale = 0;
            }

        }

        /// <summary>
        /// GameOver is called when the game is over and will stop the game
        /// </summary>
        public void GameOver()
        {
            Debug.Log("Game Over");
            Time.timeScale = 0;
        }
    }

}