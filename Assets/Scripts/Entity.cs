using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public float maxHealth = 100;
    float currentHealth;
    public Color barColor;
    public HealthBar healthBar;
    private bool isDead = true;
    public GameObject gameOverUi;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
        healthBar.SetColor(barColor);
    }

    public void ReceiveDamage(float damage) {
        if (damage >= currentHealth && (gameObject.CompareTag("InstructionMonster") || gameObject.CompareTag("DataMonster")))
            {
            // Debug.Log("damage > currentHealth");
            gameObject.GetComponent<AddressSpawner>().CheckEntityAndSpawnAddress();
            Destroy(gameObject);
        } else {
            // Debug.Log("currentHealth > damage");
            // Debug.Log("ch: " + currentHealth);
            // Debug.Log("dmg: " + damage);
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
        }
        if (currentHealth == 0 && isDead && gameObject.CompareTag("ply"))
        {
            isDead = false;
            gameOverUi.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void DealDamage(Entity entity, float damage) {
        entity.ReceiveDamage(damage);
    }
}
