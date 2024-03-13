using UnityEngine;

public class Hit : MonoBehaviour
{
    // for code
    private float currentHitCD = 0f;

    // for config
    public float hitCD;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {        
        if (currentHitCD <= 0f) {
            if (Input.GetButtonDown("Fire1")) {
                animator.SetTrigger("hit");
                currentHitCD = hitCD;
            }
        } else {
            currentHitCD -= Time.deltaTime;
        }
    }
}
