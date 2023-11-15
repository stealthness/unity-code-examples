using TMPro;
using UnityEngine;

/// <summary>
/// The Script controls the the game's UI
/// </summary>
public class MenuUI : MonoBehaviour
{

    public GameObject EndGamePanel;
    public GameObject StartGamePanel;
    public GameManager GameManager;
    

    // Start is called before the first frame update
    void Start()
    {
        StartGamePanel.gameObject.SetActive(true);
        EndGamePanel.gameObject.SetActive(false);
    }


    public void StartGame()
    {
        GameManager.StartGame();
        StartGamePanel.gameObject.SetActive(false);
    }

}
