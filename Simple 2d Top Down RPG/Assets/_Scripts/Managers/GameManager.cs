using UnityEngine;

namespace _Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {

        public static GameManager Instance;


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

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            Time.timeScale = 0;
            Debug.Log("Game Manager Started");
            StartGame();
        }
        
        
        
        public void StartGame()
        {
            Time.timeScale = 1;
            Debug.Log("Game Started");
        }
        
        
        public void GameOver()
        {
            Time.timeScale = 0;
            Debug.Log("Game Over");
        }

    }
}
