using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider Slider;
    public Image background;
    public Image fill;

    [SerializeField] private Color backgroundColor = Color.red;
    [SerializeField] private Color fillColor = Color.green;
    [SerializeField] private float MaxHealthBarValue = 100f;
    [SerializeField] private float MinHealthBarValue = 0f;


    private void Start()
    {
        Slider.maxValue = 100f;
        Slider.minValue = 0f;
        background.color = backgroundColor;
        fill.color = fillColor;
        Slider.value = 100;
    }


    public void UpdateHealthBar(int newHealthValue)
    {
        Debug.Log($"<int> newHealthValue for healthBar: {newHealthValue}");
        Slider.value = Mathf.Clamp(MinHealthBarValue, newHealthValue, MaxHealthBarValue);
    }
}
