using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider Slider;
    public Image background;
    public Image fill;

    [SerializeField] private Color backgroundColor = Color.black;
    [SerializeField] private Color fillColor = Color.white;
    [SerializeField] private float MaxHealthBarValue = 100f;
    [SerializeField] private float MinHealthBarValue = 0f;


    private void Start()
    {
        Slider.maxValue = 100f;
        Slider.minValue = 0f;
        background.color = backgroundColor;
        fill.color = fillColor;
        Slider.value = 70;
    }

    public void UpdateHealthBar(float newHealthValue)
    {
        Debug.Log($"Heath: {newHealthValue}");
        Slider.value = Mathf.Clamp(MinHealthBarValue, newHealthValue, MaxHealthBarValue);
    }

    public void UpdateHealthBar(int currentHealthValue)
    {
        Debug.Log($"currentHealthValue for healthBar: {currentHealthValue}");
        UpdateHealthBar(currentHealthValue / MaxHealthBarValue);
    }
}
