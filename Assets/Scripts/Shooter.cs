using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public float bulletRange = 10f;
    public float speed = 8f;
    public Transform firePoint;
    public GameObject bulletPrefab;
    private Vector3 initialDirection;

    public void Shoot(Transform target, Collider2D shooterCollider) {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        initialDirection = (target.position - firePoint.position).normalized;
        rb.velocity = initialDirection * speed;

        float angle = Mathf.Atan2(initialDirection.y, initialDirection.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        bullet.GetComponent<Bullet>().shooterCollider = shooterCollider;
        bullet.GetComponent<Bullet>().bulletRange = bulletRange;
        bullet.GetComponent<Bullet>().firePoint = firePoint;
    }
}
