using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [SerializeField] private GameObject deathEffect;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private float maxHealth = 100.0f;
    [SerializeField] private bool isPlayer;
    
    private float health;

    private void Start()
    {
        healthSlider.maxValue = maxHealth;
        health = maxHealth;
        healthSlider.value = health;
    }

    public void ToUpdateHealthIndicator(float damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0.0f, maxHealth);
        healthSlider.value = health;

        if(health == 0.0f)
        {
            CharacterDeath();
        }
    }

    private void CharacterDeath()
    {
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5.0f);
        Destroy(gameObject, 0.25f);

        // Отобразить UI проигрыша
        if(isPlayer)
        {
            UI_Controller ui_controller = FindObjectOfType<UI_Controller>();
            ui_controller?.ShowPanel();
        }
    }

    public void GetExtraHP(float extrHP)
    {
        health += extrHP;
        health = Mathf.Clamp(health, 0.0f, maxHealth);

        healthSlider.value = health;
    }

    // Проверяем может ли игрок подобрать дополнительные очки здоровья
    public bool isHealthPointsFull()
    {
        return health == maxHealth;
    }
}
