using UnityEngine;
using UnityEngine.SceneManagement;

public class TrainMovement : MonoBehaviour
{
    public float initialSpeed = 10f;
    public float stopXPosition = 0f; 
    private float currentSpeed;

    private void Start()
    {
        currentSpeed = initialSpeed; 
    }

    void Update()
    {
        if (currentSpeed > 0)
        {
            float distanceToStop = transform.position.x - stopXPosition;
            currentSpeed = Mathf.Lerp(0, initialSpeed, distanceToStop / 10.0f); 
            transform.position += Vector3.left * currentSpeed * Time.deltaTime;
            if (transform.position.x <= stopXPosition)
            {
                transform.position = new Vector3(stopXPosition, transform.position.y, transform.position.z);
                currentSpeed = 0;
            }
        }
    }

    void OnMouseDown()
    {
        if (currentSpeed == 0)
        {
            SceneManager.LoadScene("TrainInside");  
        }
    }
}
