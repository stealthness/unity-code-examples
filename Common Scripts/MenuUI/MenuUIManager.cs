using System;
using _Scripts.Managers;
using Unity.VisualScripting;
using UnityEngine;

namespace _Scripts.MenuUI
{
    /// <summary>
    /// The MenuManager class is responsible for showing the different menus in the game.
    /// </summary>
    public class MenuManager: MonoBehaviour
    {
        public CreditsMenuUI creditsMenuUI;
        public OptionsMenuUI optionsMenuUI;
        public NextLevelMenuUI nextLevelMenuUI;
        public StartMenuUI startMenuUI;
        public GameOverMenuUI gameOverMenuUI;

        public static MenuManager Instance;
        
        [SerializeField] private bool showStartMenuOnAwake = true;

        private void Awake()
        {
            if(MenuManager.Instance == null)
            {
                MenuManager.Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(this);

        }

        private void Start()
        {
            if (showStartMenuOnAwake)
            {
                ShowMenu("Start");
            }
        }

        /// <summary>
        /// Show the menu based on the menu name
        /// </summary>
        /// <param name="menuName"></param>
        public void ShowMenu(string menuName)
        {
            switch (menuName)
            {
                case "Options":
                    optionsMenuUI.ShowOptionsMenu();
                    break;
                case "NextLevel":
                    nextLevelMenuUI.ShowNextLevelMenu();
                    break;
                case "Credits":
                    creditsMenuUI.ShowCreditsMenu();
                    break;
                case "Start":
                    startMenuUI.ShowStartMenu();
                    break;
                case "GameOver":
                    gameOverMenuUI.ShowGameOverMenu();
                    break;
                default:
                    Debug.LogError("Menu not found");
                    break;
            }
        }
    }
}