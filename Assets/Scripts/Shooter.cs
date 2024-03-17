using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public float bulletRange = 10f;
    public float speed = 8f;
    public Transform firePoint;
    private Transform target;
    public GameObject bulletPrefab;
    private Vector3 initialDirection;

    public void Shoot() {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        initialDirection = (firePoint.position - target.position).normalized;
        rb.velocity = initialDirection * speed;
    }
}
