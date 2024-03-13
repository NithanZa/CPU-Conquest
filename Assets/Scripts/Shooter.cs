using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public float range = 2f;
    public Transform playerLoc;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public bool monsterFacingLeft = true;

    void Update() {
        Vector3 distance = playerLoc.position - firePoint.position;
        distance.z = 0f;
        if (distance.magnitude <= range) {
            if (distance.x >= 0) {
                transform.Rotate(0f, 180f, 0f);
            }
        }
    }
}
