using UnityEngine;

public class Hit : MonoBehaviour
{
    // for code
    private float currentHitCD = 0f;

    // for config
    public float hitCD;
    public Animator animator;
    public float attackRange = 0.5f;
    public Transform weaponLoc;
    public LayerMask enemyLayers;
    public float weaponDmg = 10;

    // Update is called once per frame
    void Update()
    {
        if (currentHitCD <= 0f) {
            if (Input.GetButtonDown("Fire1")) {
                animator.SetTrigger("hit");
                currentHitCD = hitCD;
                DamageHit();
            }
        } else {
            currentHitCD -= Time.deltaTime;
        }
    }

    public void DamageHit() {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(weaponLoc.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies) {
            gameObject.GetComponent<Entity>().DealDamage(enemy.gameObject.GetComponent<Entity>(), weaponDmg);
        }
    }
}
