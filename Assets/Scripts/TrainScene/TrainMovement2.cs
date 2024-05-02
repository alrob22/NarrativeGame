using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMovement2 : MonoBehaviour
{
    public float maxSpeed = 10f;  // Maximum speed of the train
    public float acceleration = 0.5f;  // Rate at which the train accelerates
    public float stopXPosition = -10f;  // X position at which the train should stop accelerating
    private float currentSpeed = 0f;  // Current speed of the train, starts at 0

    private void Update()
    {
        // Accelerate the train until it reaches the stop position or maximum speed
        if (transform.position.x > stopXPosition && currentSpeed < maxSpeed)
        {
            currentSpeed += acceleration * Time.deltaTime;  // Increment current speed based on acceleration and time
            currentSpeed = Mathf.Min(currentSpeed, maxSpeed);  // Ensure current speed does not exceed maxSpeed
        }
        else if (transform.position.x <= stopXPosition)
        {
            currentSpeed = 0;  // Stop the train when it reaches the stop position
        }

        // Move the train using the current speed
        transform.position += Vector3.left * currentSpeed * Time.deltaTime;

        // Clamp the position so the train does not go beyond the stop position
        if (transform.position.x < stopXPosition)
        {
            transform.position = new Vector3(stopXPosition, transform.position.y, transform.position.z);
            // Quit the game when the train is over the stop position
            QuitGame();
        }
    }

    private void QuitGame()
    {
        Debug.Log("Quitting game as train is over the stop position.");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
