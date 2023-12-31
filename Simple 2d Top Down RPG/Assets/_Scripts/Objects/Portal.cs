using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Portal : MonoBehaviour
{
    [SerializeField] private float timeOfDelayedMenu = 3f;
    private BoxCollider2D box;
    private Rigidbody2D rb;

    public UnityEvent OnPlayerTouch;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static;
        box = GetComponent<BoxCollider2D>();
        box.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("End of Level");
            OnPlayerTouch.Invoke();
        }
    }

}
