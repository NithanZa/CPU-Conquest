using UnityEngine;

public class MonsterShoot : Shooter
{
    public float shootRange = 5f;
    private bool shooting = false;
    public Transform playerLoc;
    public float shootCooldown = 2f;
    public Collider2D collider;

    void Update() {
        Vector3 distance = playerLoc.position - transform.position;
        distance.z = 0f;
        if (shooting && distance.magnitude > shootRange) {
            shooting = false;
            CancelInvoke(nameof(ShootPlayer));
        } else if (!shooting && distance.magnitude < shootRange) {
            InvokeRepeating(nameof(ShootPlayer), 0f, shootCooldown);
            shooting = true;
        }
    }

    void ShootPlayer() {
        Shoot(playerLoc, collider);
    }
}
