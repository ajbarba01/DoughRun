using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 moveInput;
    private SpriteRenderer spriteRenderer;

    public Sprite upSprite, downSprite, leftSprite, rightSprite; // Assign these in Unity

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        moveInput = Vector2.zero; // Reset movement every frame

        int vertical = 0;
        int horizontal = 0;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
            vertical++;
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            vertical--;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            horizontal--;
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            horizontal++;
        }


        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            moveInput = Vector2.up;
            spriteRenderer.sprite = upSprite;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            moveInput = Vector2.down;
            spriteRenderer.sprite = downSprite;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveInput = Vector2.left;
            spriteRenderer.sprite = leftSprite;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveInput = Vector2.right;
            spriteRenderer.sprite = rightSprite;
        }

        moveInput.x = horizontal;
        moveInput.y = vertical;
        moveInput.Normalize();
    }

    void FixedUpdate()
    {
        if (moveInput != Vector2.zero) // Move only if a key is pressed
        {
            transform.position += (Vector3)(moveInput * speed * Time.fixedDeltaTime);
        }
    }
}
