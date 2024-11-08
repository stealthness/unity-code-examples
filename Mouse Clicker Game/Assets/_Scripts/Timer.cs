using TMPro;
using UnityEngine;

namespace _Scripts
{
    public class Timer : MonoBehaviour
    {
        private const int GameTimeLength = 60;
        private int _gameTimer;

        public TextMeshProUGUI TimerText;

        // Start is called before the first frame update
        void Start()
        {
            ResetTimer();
        }

        /// <summary>
        /// Starts the timer
        /// </summary>
        public void StartTimer()
        {
            ResetTimer();
            InvokeRepeating(nameof(NextSec), 1f, 1f);
        }

        /// <summary>
        /// Checks if the game timer has reached 0, if so ends the game, otherwise decrements the timer
        /// </summary>
        private void NextSec()
        {

            if (_gameTimer <= 0)
            {
                CancelInvoke();
                TargetManager.Instance.CancelTargetSpawn();
                GameManager.Instance.EndGame();
            }
            else
            {
                _gameTimer--;
                TimerText.text = $"{_gameTimer}";
            }

        }

        /// <summary>
        /// Resets the timer
        /// </summary>
        public void ResetTimer()
        {
            _gameTimer = GameTimeLength;
            TimerText.text = $"{_gameTimer}";
        }
    }
}
