using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    public float speed = 800f;
    private bool isFacingRight = true;
    public Animator animator;
    public Sprite planeSprite;
    public SpriteRenderer spriteRenderer;

    [SerializeField] private Rigidbody2D rb;

    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        float horizontalSpeed = horizontal * speed;
        float verticalSpeed = vertical * speed;
        animator.SetFloat("speed", (Mathf.Abs(horizontalSpeed) + Mathf.Abs(verticalSpeed))/2);
        rb.velocity = new Vector2(horizontalSpeed, verticalSpeed);
        Flip();
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
            Transform hbTransform = gameObject.transform.Find("HB Canvas");
            Vector3 hbScale = hbTransform.localScale;
            hbScale.x *= -1f;
            hbTransform.localScale = hbScale;
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo) {
        if (hitInfo.CompareTag("PlaneTrigger")) {
            animator.enabled = false;
            spriteRenderer.sprite = planeSprite;
        }
        if (hitInfo.CompareTag("Memory")) {
            gameObject.transform.Find("IAT").GetComponent<TextMeshPro>().SetText("hello");
        }
    }

    void OnTriggerExit2D(Collider2D hitInfo) {
        if (hitInfo.CompareTag("PlaneTrigger")) {
            animator.enabled = true;
        }
    }
}