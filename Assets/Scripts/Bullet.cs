using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector] public Collider2D shooterCollider;
    [HideInInspector] public float bulletRange;
    [HideInInspector] public Transform firePoint;
    private float distance;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo != shooterCollider) {
            Debug.Log(hitInfo.name);
            shooterCollider.GetComponentInParent<Entity>().DealDamage(hitInfo.GetComponentInParent<Entity>(), 10f);
            Destroy(gameObject);
        }
    }

    void Update() {
        distance = (transform.position - firePoint.position).magnitude;
        if (distance > bulletRange) {
            Destroy(gameObject);
        }
    }
}
