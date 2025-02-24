using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 moveInput;
    public SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    
    public Sprite upSprite, downSprite, leftSprite, rightSprite;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Pause.isPaused) {
            return;
        }
        moveInput = Vector2.zero;

        // Movement Input
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
            moveInput = Vector2.up;
            spriteRenderer.sprite = upSprite;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            moveInput = Vector2.down;
            spriteRenderer.sprite = downSprite;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            moveInput = Vector2.left;
            spriteRenderer.sprite = leftSprite;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            moveInput = Vector2.right;
            spriteRenderer.sprite = rightSprite;
        }

        moveInput.Normalize();
    }

    void FixedUpdate()
    {
        if (moveInput != Vector2.zero)
        {
            rb.MovePosition(rb.position + moveInput * speed * Time.fixedDeltaTime);
        }
    }
}
