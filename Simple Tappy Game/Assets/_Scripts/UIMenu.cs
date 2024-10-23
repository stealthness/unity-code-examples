using UnityEngine;

namespace _Scripts{

    public class UIMenu : MonoBehaviour
    {
        public static UIMenu Instance;
        
        
        public GameObject StartPanel;
        public GameObject EndPanel;

        private const float timeDelay = 1f;

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

        public void ShowEndPanel()
        {
            Invoke(nameof(ShowEndPanelDelayed), timeDelay);
        }

       private void ShowEndPanelDelayed()
        {
            EndPanel.SetActive(true);
        }
    }
}

