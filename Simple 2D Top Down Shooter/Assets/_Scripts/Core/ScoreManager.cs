using System;
using UnityEngine;
using UnityEngine.Events;

namespace _Scripts.Core
{
    /// <summary>
    /// Score class that is responsible for handling the score of the player
    /// </summary>
    public class ScoreManager : MonoBehaviour
    {
        
        public static ScoreManager Instance;
        
        private int _score;
        
        public UnityEvent<int> OnScoreChanged;

        private void Awake()
        {
            if(Instance == null)
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
            _score = 0;
            OnScoreChanged?.Invoke(_score);
        }

        /// <summary>
        /// Adds the score to the current score and invokes the OnScoreChanged event
        /// </summary>
        /// <param name="score"></param>
        public void AddScore(int score)
        {
            _score += score;
            OnScoreChanged?.Invoke(_score);
        }
        
        public int GetScore()
        {
            return _score;
        }
        
        
    }
}
