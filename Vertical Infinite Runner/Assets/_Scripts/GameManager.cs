using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] private float minFrequencyTime = 0.1f;
    [SerializeField] private float maxFrequencyTime = 2f;

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
        CollidableManager.Instance.StartSpawningCollidableObjects(minFrequencyTime, maxFrequencyTime);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }

}
