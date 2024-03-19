using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector] public Collider2D shooterCollider;
    [HideInInspector] public float bulletRange;
    [HideInInspector] public Transform firePoint;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo != shooterCollider) {
            Debug.Log(hitInfo.name);
            Destroy(gameObject);
        }
    }

    void 
}
