using UnityEngine;

public class BackgroundLooper : MonoBehaviour
{
    public float speed = 0.5f; // Speed of the background scroll
    private float width; // Width of the background image

    void Start()
    {
        // Get the width of the sprite
        width = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        // Move the background left by speed * Time.deltaTime
        transform.Translate(-speed * Time.deltaTime, 0, 0);

        // Check if the background has moved entirely out of view
        if (transform.position.x <= -width)
        {
            // Reposition it to the right of the original position to loop continuously
            transform.position = new Vector3(width, transform.position.y, transform.position.z);
        }
    }
}
