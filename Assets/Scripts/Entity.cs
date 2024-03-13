using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public float maxHealth = 100;
    protected float currentHealth;

    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
    }

    public void ReceiveDamage(float damage) {
        currentHealth -= damage;
        healthBar.SetHealth(damage);
    }

    public void DealDamage(Entity entity, float damage) {
        entity.ReceiveDamage(damage);
        healthBar.SetHealth(damage);
    }
}
