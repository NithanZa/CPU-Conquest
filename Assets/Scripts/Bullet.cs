using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    private Vector3 initialDirection;
    public GameObject monster;
    private MonsterShoot monsterShoot;
    // Start is called before the first frame update
    void Start()
    {
        monsterShoot = monster.GetComponent<MonsterShoot>();
        initialDirection = (monsterShoot.playerLoc.position - transform.position).normalized;
        rb.velocity = initialDirection * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);
        Destroy(gameObject);
    }
}
