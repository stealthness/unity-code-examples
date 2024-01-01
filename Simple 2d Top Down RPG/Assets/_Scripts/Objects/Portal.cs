using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Portal : MonoBehaviour
{
    public UnityEvent OnPlayerTouch;

    private BoxCollider2D _box;
    private Rigidbody2D rb;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static;
        _box = GetComponent<BoxCollider2D>();
        _box.isTrigger = true;
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
