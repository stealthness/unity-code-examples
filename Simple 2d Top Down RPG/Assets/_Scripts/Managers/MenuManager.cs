using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public static MenuManager Instance;
    public TextMeshProUGUI GoldText;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }
        Instance = this;
    }

    public void UpdateGoldAmountText(int goldAmount)
    {
        GoldText.text = goldAmount.ToString();
    }



    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("MainScene");
    }
}
