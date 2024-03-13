using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public Image fill;

    public void SetMaxHealth(float health) {
        slider.maxValue = health;
    }

    // Start is called before the first frame update
    public void SetHealth(float health) {
        slider.value = health;
    }

    public void SetColor(Color color) {
        fill.color = color;
    }
}
