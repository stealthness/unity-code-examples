using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{


    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("MainScene");
    }
}
