using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts.Managers
{
    
    public class GameManager : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            Debug.Log("Game Manager Start");
        }

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
    }
}