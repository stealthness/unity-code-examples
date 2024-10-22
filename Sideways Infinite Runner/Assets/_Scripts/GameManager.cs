using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts
{
    public class GameManager : MonoBehaviour
    {
    
        public static GameManager Instance;
        public GameObject player;
    
        private GameState _gameState;
    
    
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }
        }
    
        private void Start()
        {
            Time.timeScale = 1.0f;
            _gameState = GameState.STARTED;
    
        }
    
        public void EndGame()
        {
            Destroy(player);
            _gameState = GameState.ENDED;
        }
    
        private void Update()
        {
            
            if (_gameState == GameState.ENDED && Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
        }
    
    }
    
    enum GameState
    {
        MENU, STARTED, ENDED
    }

}

