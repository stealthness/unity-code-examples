using System.Collections;
using UnityEngine;

public class NPCMovement : Movement
{
    private readonly float fadeDuration = 0.9f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
 
        if (collision.CompareTag("Player"))
        {
            Debug.Log("NPC Hit Player");
            box.enabled = false;
            StartCoroutine(nameof(FadeObject));
        }
    }



    IEnumerator FadeObject()
    {

        Color startColor = sr.material.color;

        // Set the target color with initial alpha set to 0
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 0f);

        // Time elapsed during the fade
        float currentTime = 0.0f;

        while (currentTime < fadeDuration)
        {

            currentTime += Time.deltaTime;
            float lerpFactor = currentTime / fadeDuration;
            sr.material.color = Color.Lerp(startColor, targetColor, lerpFactor);

            // Wait for the next frame
            yield return null;
        }

        // Ensure the final color is set
        sr.material.color = targetColor;
        Destroy(gameObject);


    }
}
