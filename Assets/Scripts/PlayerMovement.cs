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
    private bool pcIncreased;
    private bool instructionAddressConverted = false;
    private bool dataAddressConverted = false;
    private bool mdrTriggered = false;
    private bool cirTriggered = false;
    private bool decoded = false;
    private bool calculated = false;
    private bool accTriggered = false;
    public TextMeshPro pcStatusText;
    public TextMeshPro pcNumberText;
    public TextMeshPro decoderStatusText;
    public TextMeshPro calculatorStatusText;
    public TextMeshPro instructionLabelText;
    public TextMeshPro dataLabelText;
    public TextMeshPro instructionNumbersText;
    public TextMeshPro dataNumbersText;
    
    readonly private string[] translatedArray = new string[16] {
        "Add 8", "Add 6", "Add 5", "Minus 4",
        "Minus 2", "Times 4", "Times 3", "Times 6",
        "1", "15", "5", "8",
        "0", "2", "10", "6"
    };

    readonly private string[] dataArray = new string[16] {
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
            try {
                Transform resultTransform = gameObject.transform.Find("Result");
                Vector3 resultScale = resultTransform.localScale;
                resultScale.x *= -1f;
                resultTransform.localScale = resultScale;
            } catch (Exception e) {}
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo) {
        if (hitInfo.CompareTag("PCTrigger") && !pcIncreased) {
            pcStatusText.SetText("Increased!");
            pcNumberText.SetText("1");
            pcIncreased = true;
        }
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
            instructionLabelText.SetText("");
            dataLabelText.SetText("");
            instructionNumbersText.SetText("Instruction address converted!");
            dataNumbersText.SetText("Data address converted!");
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
            int itIndex = Array.IndexOf(dataArray, itText[13..]);
            Debug.Log(itIndex);
            string instruction = translatedArray[itIndex]; // main difference is using `translatedArray`
            gameObject.transform.Find("IT").GetComponent<TextMeshPro>().SetText("Instruction: " + instruction);

            string dtText = gameObject.transform.Find("DT").GetComponent<TextMeshPro>().text;
            int dtIndex = Array.IndexOf(dataArray, dtText[6..]);
            Debug.Log(dtIndex);
            string data = translatedArray[dtIndex];
            gameObject.transform.Find("DT").GetComponent<TextMeshPro>().SetText("Data: " + data);
            decoderStatusText.SetText("Decoded!");
            decoded = true;
        }
        if (hitInfo.CompareTag("CalculatorTrigger") && !calculated) {
            string itText = gameObject.transform.Find("IT").GetComponent<TextMeshPro>().text;
            string instruction = itText[13..];

            string dtText = gameObject.transform.Find("DT").GetComponent<TextMeshPro>().text;
            int data = Convert.ToInt32(dtText[6..]);
            
            int instructionLength = instruction.Length;
            string instructionOperator = instruction[..(instructionLength-2)];
            int instructionValue = instruction[instructionLength-1] - '0';

            int result = -1;

            Debug.Log(data);
            Debug.Log(instructionOperator);
            Debug.Log(instruction[instructionLength-1]);
            Debug.Log(instructionValue);

            if (instructionOperator == "Times") { result = data * instructionValue; }
            else if (instructionOperator == "Minus") { result = data - instructionValue; }
            else if (instructionOperator == "Add") { result = data + instructionValue; }

            Destroy(gameObject.transform.Find("IT").gameObject);

            GameObject dt = gameObject.transform.Find("DT").gameObject; // reusing DT for result
            Renderer resultRenderer = dt.GetComponent<Renderer>();
            Material material = resultRenderer.material;
            material.SetColor("_OutlineColor", Color.black);
            dt.name = "Result";
            TextMeshPro tmp = dt.GetComponent<TextMeshPro>();
            tmp.SetText("Result: " + result.ToString());
            tmp.color = Color.white;

            calculatorStatusText.SetText("Calculated!");
            calculated = true;
        }
        if (hitInfo.CompareTag("ACCTrigger") && !accTriggered) {
            GameObject result = gameObject.transform.Find("Result").gameObject;

            GameObject resultClone = Instantiate(result);
            resultClone.transform.SetParent(null);
            resultClone.name = "Result Clone";
            resultClone.transform.localScale = new Vector3(10, 10, 2);
            resultClone.transform.position = new Vector3(-46.5f, -57f, 0f);

            accTriggered = true;
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