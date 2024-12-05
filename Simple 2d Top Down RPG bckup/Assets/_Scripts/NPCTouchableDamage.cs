using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class NPCTouchableDamage : MonoBehaviour, ITouchableDamage
{



    public void OnDamageIfTouched(Health health, int amount)
    {
        health.ReduceHealth(amount);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player hit TouchableDamage");
            OnDamageIfTouched(collision.GetComponent<Health>(), 13);
        }
    }

}
