using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update

    public UnityEvent OnDeath;
    public UnityEvent<int> OnHealthChange;

    [SerializeField] private int currentHealth;
    private const int maxHealth = 100;
    private const int initialHealth = 100;

    private void Start()
    {
        currentHealth = initialHealth;
    }

    public int GetHealth()
    {
        return currentHealth;
    }

    public void ReduceHealth(int amount)
    {
        Debug.Log($"reduce health by {amount} from {currentHealth}");
        if (currentHealth > amount) 
        {
            currentHealth -= amount;
            OnHealthChange?.Invoke(currentHealth);
        }
        else
        {
            Debug.Log("Death");
            currentHealth = 0;
            OnHealthChange?.Invoke(currentHealth);
            OnDeath?.Invoke();
        }
        
    }

    public void IncreaseHealth(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
    }


}
