using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private void Start()
    {
        Time.timeScale = 1.0f;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log($"collision {collision.name} has left the area");
        if (collision.CompareTag("Piller"))
        {
            Destroy(collision.gameObject);
        }
    }
}
