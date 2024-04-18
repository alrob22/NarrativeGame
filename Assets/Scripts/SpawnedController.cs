using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedController : MonoBehaviour
{
    public SenGameController gameController;
    // Start is called before the first frame update
    void Awake()
    {
        gameController = GameObject.FindWithTag("Player").GetComponent<SenGameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.CompareTag("Coin"))
        {
            transform.Translate(Vector2.right * Time.deltaTime * gameController.runSpeed);
        }
        else
        {
            transform.Translate(Vector2.left * Time.deltaTime * gameController.runSpeed);
        }
        if (transform.position.x < -9.5 || transform.position.x > 9.5)
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Coin") && this.gameObject.CompareTag("Spirit"))
        {
            // move off the screen
            gameController.spiritsSaved++;
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }
        else if (!col.gameObject.CompareTag("Player") && this.gameObject.CompareTag("Coin"))
        {
            Destroy(this.gameObject);
        }
    }
}
