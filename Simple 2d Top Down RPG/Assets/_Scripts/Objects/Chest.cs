using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class Chest : Collidable
{
    public Sprite emptyChest;
    public AudioSource PickupCoinSound;
    private SpriteRenderer spriteRenderer;

    private readonly float fadeDuration = 0.5f;
    private readonly int containedGoldAmount = 10;


    public UnityEvent<int> IncreaseWalletGold;


    //protected override void Awake()
    protected override void Awake()
    {
        base.Awake();
        spriteRenderer = GetComponent<SpriteRenderer>();
        PickupCoinSound = GetComponent<AudioSource>();
    }



    protected override void OnCollide(Collider2D collider)
    {
        if (!_isCollidable)
        {
            return;
        }

        if (collider.CompareTag("Player"))
        {
            Debug.Log("<1>Chest Hit");
            collider.GetComponent<Health>().ReduceHealth(10);
            _box.enabled = false;
            PickupCoinSound.Play();
            IncreaseWalletGold.Invoke(containedGoldAmount);
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
