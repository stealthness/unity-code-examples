using TMPro;
using UnityEngine;

namespace _Scripts.Managers
{
    public class GameUIManager : MonoBehaviour
    {

        public TextMeshProUGUI scoreTest;
    
    
        public void UpdateScoreUI(int newScore)
        {
            scoreTest.text = $"Score: {newScore}";
        }
    }
}
