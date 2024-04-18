using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenGameController : MonoBehaviour
{
    public float runSpeed;
    public float vertSpeed;
    public float UpLimit;
    public float DownLimit;
    public int spiritsEaten = 0;
    public int spiritsSaved = 0;

    [SerializeField] private int timeLimit;
    [SerializeField] private int dumplingCount;
    public GameObject Coin;
    // Start is called before the first frame update
    void Start()
    {
        timeLimit = 60;
        dumplingCount = 0;
        spiritsEaten = 0;
        spiritsSaved = 0;
        InvokeRepeating("timerCountDown", 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") != 0 && transform.position.y >= DownLimit && transform.position.y <= UpLimit)
        {
            transform.Translate(Vector2.up * Time.deltaTime * Input.GetAxis("Vertical") * vertSpeed);
            if (transform.position.y < DownLimit) {
                transform.position = new Vector2(transform.position.x, DownLimit);
            }
            if (transform.position.y > UpLimit)
            {
                transform.position = new Vector2(transform.position.x, UpLimit);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Coin, transform.position, Quaternion.identity);
        }
        if (dumplingCount == 5)
        {
            // scene transition
            Time.timeScale = 0;
        }
        if (spiritsEaten == 7)
        {
            // scene transition
            Time.timeScale = 0;
        }
        if (timeLimit <= 0)
        {
            // scene transition
            Time.timeScale = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Dumpling"))
        {
            Destroy(col.gameObject);
            dumplingCount++;
        }
        else if (col.gameObject.CompareTag("Spirit"))
        {
            Destroy(col.gameObject);
            timeLimit += 10;
            spiritsEaten++;
        }
        else if (col.gameObject.CompareTag("Wall"))
        {
            Destroy(col.gameObject);
            timeLimit -= 10;
        }
    }

    void timerCountDown()
    {
        timeLimit--;
    }
}
