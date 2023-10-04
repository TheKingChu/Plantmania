using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBarUI : MonoBehaviour
{
    public Slider healthbarSlider;
    public TextMeshProUGUI healtbarValueText;
    public int maxHealth, currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        // sets the text
        healtbarValueText.text = currentHealth.ToString() + "/" + maxHealth.ToString();
        // sets the slider values
        healthbarSlider.value = currentHealth;
        healthbarSlider.maxValue = maxHealth;
    }
}
