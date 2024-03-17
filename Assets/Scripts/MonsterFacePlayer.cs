using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFacePlayer : MonoBehaviour
{
    public float detectionRange = 10f;
    public Transform playerLoc;
    public bool monsterFacingLeft = true;

    void Update() {
        Vector3 distance = playerLoc.position - transform.position;
        distance.z = 0f;
        if (distance.magnitude <= detectionRange) {
            if (distance.x >= 0 == monsterFacingLeft) {
                transform.Rotate(0f, 180f, 0f);
            }
            monsterFacingLeft = !(distance.x >= 0);
        }
    }
}
