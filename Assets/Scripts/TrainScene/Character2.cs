using UnityEngine;
using UnityEngine.SceneManagement;

public class Character2 : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public string nextSceneName;
    private SpriteRenderer spriteRenderer; // Add a reference to the SpriteRenderer
    public int scoreThreshold; // The score threshold to decide which scene to load
    public string highScoreScene = "HE"; // Scene to load if the score is above the threshold
    public string lowScoreScene = "BE";  // Scene to load if the score is below the threshold


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
            // Assuming Player.totalScore is a static variable accessible from anywhere
            if (Player.totalPoints > scoreThreshold)
            {
                SceneManager.LoadScene(highScoreScene);
                Debug.Log(Player.totalPoints);
            }
            else
            {
                SceneManager.LoadScene(lowScoreScene);
                Debug.Log(Player.totalPoints);
            }
        }
    }
}
