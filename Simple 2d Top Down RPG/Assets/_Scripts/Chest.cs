using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Chest : MonoBehaviour
{
    public Sprite emptyChest;
    public AudioSource PickupCoinSound;
    private SpriteRenderer spriteRenderer;
    private readonly float fadeDuration = 0.5f;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(PlayerController.Tag))
        {
            Debug.Log("Chest Hit");
            collision.GetComponent<Health>().ReduceHealth(10);
            GetComponent<Collider2D>().enabled = false;
            GetComponent<AudioSource>().Play();
            spriteRenderer.sprite = emptyChest;
            StartCoroutine(FadeObject());
        }
    }


    IEnumerator FadeObject()
    {
 
        Color startColor = spriteRenderer.material.color;

        // Set the target color with initial alpha set to 0
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 0f);

        // Time elapsed during the fade
        float currentTime = 0.0f;

        while (currentTime < fadeDuration)
        {

            currentTime += Time.deltaTime;
            float lerpFactor = currentTime / fadeDuration;
            spriteRenderer.material.color = Color.Lerp(startColor, targetColor, lerpFactor);

            // Wait for the next frame
            yield return null;
        }

        // Ensure the final color is set
        spriteRenderer.material.color = targetColor;
        Destroy(gameObject);


    }
}
