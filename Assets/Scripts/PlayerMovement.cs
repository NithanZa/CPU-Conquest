using System;
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
    public Sprite redPlaneSprite;
    public SpriteRenderer spriteRenderer;
    private bool instructionAddressConverted = false;
    private bool dataAddressConverted = false;
    private bool mdrTriggered = false;
    private bool cirTriggered = false;
    private bool decoded = false;
    public TextMeshPro decoderStatusText;
    
    readonly private string[] translatedArray = new string[16] {
        "9557", "Minus 4", "2789", "7807",
        "Times 6", "3957", "Minus 2", "1548",
        "Add 6", "4472", "Times 4", "8842",
        "Add 8", "Add 5", "9433", "Times 3"
    };

    readonly private string[] dataArray = new string[] {
        "1100", "0011", "1011", "1110",
        "0111", "1001", "0100", "1101",
        "0001", "1111", "0101", "1000",
        "0000", "0010", "1010", "0110"
    };



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

            try {
                Transform dtTransform = gameObject.transform.Find("DT");
                Vector3 dtScale = dtTransform.localScale;
                dtScale.x *= -1f;
                dtTransform.localScale = dtScale;
            } catch (Exception e) {}

            try {
                Transform itTransform = gameObject.transform.Find("IT");
                Vector3 itScale = itTransform.localScale;
                itScale.x *= -1f;
                itTransform.localScale = itScale;
            } catch (Exception e) {}
            
            
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo) {
        if (hitInfo.CompareTag("PlaneTrigger")) {
            animator.enabled = false;
            spriteRenderer.sprite = planeSprite;
        }
        if (hitInfo.CompareTag("PlaneTriggerRed")) {
            animator.enabled = false;
            spriteRenderer.sprite = redPlaneSprite;
        }
        if (hitInfo.CompareTag("InstructionMemory") && !instructionAddressConverted) {
            string itText = gameObject.transform.Find("IT").GetComponent<TextMeshPro>().text;
            int itAddress = Convert.ToInt32(itText[21..], 2);
            string instruction = dataArray[itAddress];
            gameObject.transform.Find("IT").GetComponent<TextMeshPro>().SetText("Instruction: " + instruction);
            instructionAddressConverted = true;
        }
        if (hitInfo.CompareTag("DataMemory") && !dataAddressConverted) {
            string dtText = gameObject.transform.Find("DT").GetComponent<TextMeshPro>().text;
            int dtAddress = Convert.ToInt32(dtText[14..], 2);
            string data = dataArray[dtAddress];
            gameObject.transform.Find("DT").GetComponent<TextMeshPro>().SetText("Data: " + data);
            dataAddressConverted = true;
        }
        if (hitInfo.CompareTag("MDRTrigger") && !mdrTriggered) {
            Debug.Log("Hello???");
            GameObject it = gameObject.transform.Find("IT").gameObject;
            GameObject dt = gameObject.transform.Find("DT").gameObject;

            GameObject itClone = Instantiate(it);
            GameObject dtClone = Instantiate(dt);

            itClone.transform.SetParent(null);
            dtClone.transform.SetParent(null);

            itClone.name = "IT Clone";
            dtClone.name = "DT Clone";
            
            itClone.transform.localScale = new Vector3(10, 10, 2);
            dtClone.transform.localScale = new Vector3(10, 10, 2);
            
            itClone.transform.position = new Vector3(-4.5f, 38f, 0f);
            dtClone.transform.position = new Vector3(-4.5f, 32f, 0f);

            mdrTriggered = true;
        }
        if (hitInfo.CompareTag("CIRTrigger") && !cirTriggered) {
            Debug.Log("Hello???");
            GameObject it = gameObject.transform.Find("IT").gameObject;
            GameObject dt = gameObject.transform.Find("DT").gameObject;

            GameObject itClone = Instantiate(it);
            GameObject dtClone = Instantiate(dt);

            itClone.transform.SetParent(null);
            dtClone.transform.SetParent(null);

            itClone.name = "IT Clone";
            dtClone.name = "DT Clone";
            
            itClone.transform.localScale = new Vector3(10, 10, 2);
            dtClone.transform.localScale = new Vector3(10, 10, 2);
            
            itClone.transform.position = new Vector3(-46.5f, -27.5f, 0f);
            dtClone.transform.position = new Vector3(-46.5f, -33.5f, 0f);

            cirTriggered = true;
        }
        if (hitInfo.CompareTag("DecoderTrigger") && !decoded) {
            string itText = gameObject.transform.Find("IT").GetComponent<TextMeshPro>().text;
            int itAddress = Convert.ToInt32(itText[13..], 2);
            string instruction = translatedArray[itAddress]; // main difference is using `translatedArray`
            gameObject.transform.Find("IT").GetComponent<TextMeshPro>().SetText("Instruction: " + instruction);
            string dtText = gameObject.transform.Find("DT").GetComponent<TextMeshPro>().text;
            int dtAddress = Convert.ToInt32(dtText[6..], 2);
            string data = translatedArray[dtAddress];
            gameObject.transform.Find("DT").GetComponent<TextMeshPro>().SetText("Data: " + data);
            decoderStatusText.SetText("Decoded!");
            decoded = true;
        }
        
    }

    void OnTriggerExit2D(Collider2D hitInfo) {
        if (hitInfo.CompareTag("PlaneTrigger")) {
            animator.enabled = true;
        }
        if (hitInfo.CompareTag("PlaneTriggerRed")) {
            animator.enabled = true;
        }
    }
}