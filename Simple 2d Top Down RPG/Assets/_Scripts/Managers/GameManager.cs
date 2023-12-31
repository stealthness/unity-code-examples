using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private const float DelayedMenuTimer = 3f;
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void OnDeath()
    {
        Debug.Log("GM: Player Death -> load main menu");
        Invoke(nameof(LoadMenu), DelayedMenuTimer);
    }


    public void EndOfLevelReached()
    {
        Debug.Log($"GM: End of level Reached -> back to main menu in {DelayedMenuTimer} secs");
        Invoke(nameof(LoadMenu), DelayedMenuTimer);
    }

    private void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadLevel(string levelName)
    {
        if (levelName == null)
        {
            SceneManager.LoadScene(0);
        }
        SceneManager.LoadScene(levelName);
    }
}
