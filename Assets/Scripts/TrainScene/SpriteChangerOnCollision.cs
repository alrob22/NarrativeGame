using UnityEngine;

public class SpriteChangerOnCollision : MonoBehaviour
{
    public Sprite defaultSprite;
    public Sprite newSprite;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = defaultSprite;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision Detected with: " + other.gameObject.name);  // Log the name of the object collided with.
        if (other.CompareTag("Player"))  // Check if the colliding object is tagged as "Player".
        {
            Debug.Log("Collided with Player. Changing sprite.");  // Confirm collision with Player in the Console.
            spriteRenderer.sprite = newSprite;
        }
    }
}
