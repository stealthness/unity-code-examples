using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.Managers
{
    public class UIMenuManager : MonoBehaviour
    {
        public void OnStartButtonClicked()
        {
            SceneManager.LoadScene(1);
        }
    }
}