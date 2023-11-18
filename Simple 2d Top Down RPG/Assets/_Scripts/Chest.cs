using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Chest : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private readonly float TimeDelay = 0.5f;
    public Sprite emptyChest;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(PlayerController.Tag))
        {
            Debug.Log("Chest Hit");
            Invoke(nameof(delayedDestroy), TimeDelay);
            GetComponent<Collider2D>().enabled = false;
            spriteRenderer.sprite = emptyChest;
        }
    }

    private void delayedDestroy()
    {
        Destroy(gameObject);
    }
}
