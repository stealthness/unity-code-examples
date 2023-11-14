using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse click");
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);

            var collider = Physics2D.OverlapPoint(mousePos);

            if (collider != null)
            {
                Debug.Log($"hit {collider.name}");
                if (collider.CompareTag("Target"))
                {
                    Destroy(collider.gameObject);
                }

            }
        }
    }
}
