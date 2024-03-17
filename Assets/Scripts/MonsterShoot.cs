using UnityEngine;

public class MonsterShoot : Shooter
{
    public float shootRange = 5f;
    private bool shooting = false;
    public Transform playerLoc;

    void Update() {
        Vector3 distance = playerLoc.position - transform.position;
        distance.z = 0f;
        if (shooting && distance.magnitude > shootRange) {
            shooting = false;
            CancelInvoke(nameof(Shoot));
        } else if (!shooting && distance.magnitude < shootRange) {
            InvokeRepeating(nameof(Shoot), 0f, 2f);
            shooting = true;
        }
    }
}
