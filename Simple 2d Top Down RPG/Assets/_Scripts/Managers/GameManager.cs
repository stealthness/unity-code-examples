using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
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
        Invoke(nameof(LoadMenu), 3f);
    }


    private void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}
