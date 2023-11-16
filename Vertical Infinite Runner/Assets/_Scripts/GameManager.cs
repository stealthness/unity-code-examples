using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] private float minFrequencyTime = 0.1f;
    [SerializeField] private float maxFrequencyTime = 2f;
    private readonly float initialGameSpeed = 5f;
    private readonly float gameFrequancySpeedIncrease = 5f;
    private readonly float percentageSpeedIncrease = 1.01f;

    public float GameSpeed { get; private set; }

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }
        Instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1.0f;
        GameSpeed = initialGameSpeed;
        CollidableManager.Instance.StartSpawningCollidableObjects(minFrequencyTime, maxFrequencyTime);
        InvokeRepeating(nameof(IncreaseGameSpeed), 0f, gameFrequancySpeedIncrease);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void IncreaseGameSpeed()
    {
        GameSpeed *= percentageSpeedIncrease;
    }

}
