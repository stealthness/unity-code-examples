using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class Chest : Collidable
{
    public Sprite EmptyChestSprite;
    public AudioSource PickupCoinSoundClip;
    private SpriteRenderer _spriteRenderer;

    [SerializeField] private readonly int _containedGoldAmount = 10;
    [SerializeField] private readonly float _fadeDuration = 0.5f;
    [SerializeField] private readonly float _timeBeforeChestFades = 2f;
    public UnityEvent<int> IncreaseWalletGold;



    protected override void Awake()
    {
        base.Awake();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        PickupCoinSoundClip = GetComponent<AudioSource>();
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
            PickupCoinSoundClip.Play();
            IncreaseWalletGold.Invoke(_containedGoldAmount);
            _spriteRenderer.sprite = EmptyChestSprite;
            Invoke(nameof(FadeChest), _timeBeforeChestFades);
        }
    }

    private void FadeChest()
    {
        StartCoroutine(FadeObject());
    }


    IEnumerator FadeObject()
    {
 
        Color startColor = _spriteRenderer.material.color;

        // Set the target color with initial alpha set to 0
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 0f);

        // Time elapsed during the fade
        float currentTime = 0.0f;

        while (currentTime < _fadeDuration)
        {

            currentTime += Time.deltaTime;
            float lerpFactor = currentTime / _fadeDuration;
            _spriteRenderer.material.color = Color.Lerp(startColor, targetColor, lerpFactor);

            // Wait for the next frame
            yield return null;
        }

        // Ensure the final color is set
        _spriteRenderer.material.color = targetColor;
        Destroy(gameObject);


    }
}
