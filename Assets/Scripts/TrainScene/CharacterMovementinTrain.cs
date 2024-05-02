using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMovementInTrain : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public string nextSceneName;
    private SpriteRenderer spriteRenderer; // Add a reference to the SpriteRenderer

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Check if there is horizontal movement
        if (movement.x != 0)
        {
            // Flip the sprite by setting the x local scale to -1 if moving left (negative), 1 if moving right (positive)
            spriteRenderer.flipX = movement.x > 0;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "SwitchSceneTrigger")
        {
            if (!string.IsNullOrEmpty(nextSceneName))
            {
                SceneManager.LoadScene(nextSceneName);
            }
            else
            {
                Debug.LogError("Next scene name is not set in the Inspector!");
            }
        }
    }
}
