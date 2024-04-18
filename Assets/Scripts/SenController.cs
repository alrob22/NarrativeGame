using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenController : MonoBehaviour
{
    public SenGameController gameController;
    public GameObject Dumpling;
    public GameObject Spirit;
    public GameObject Wall;

    public float UpLimit;
    public float DownLimit;
    public float movementSpeed = 1;
    public float moveDirection = 1;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnDumpling", 10.0f);
        Invoke("SpawnSpirit", 5.0f);
        Invoke("SpawnWall", 2.5f);
        Invoke("ChangeSpeed", 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * movementSpeed * moveDirection);
        if (transform.position.y < DownLimit)
        {
            transform.position = new Vector2(transform.position.x, DownLimit);
            CancelInvoke("ChangeSpeed");
            Invoke("ChangeSpeed", 0.0f);
        }
        if (transform.position.y > UpLimit)
        {
            transform.position = new Vector2(transform.position.x, UpLimit);
            CancelInvoke("ChangeSpeed");
            Invoke("ChangeSpeed", 0.0f);
        }
    }
    void ChangeSpeed()
    {
        movementSpeed = Random.Range(1.0f, 5.0f);
        moveDirection *= -1;
        Invoke("ChangeSpeed", Random.Range(0.5f, 3.0f));
    }
    void SpawnDumpling()
    {
        Instantiate(Dumpling, transform.position, Quaternion.identity);
        Invoke("SpawnDumpling", Random.Range(8f, 12f));
    }
    void SpawnSpirit()
    {
        Instantiate(Spirit, transform.position, Quaternion.identity);
        Invoke("SpawnSpirit", Random.Range(3f, 7f));
    }
    void SpawnWall()
    {
        Instantiate(Wall, transform.position, Quaternion.identity);
        Invoke("SpawnWall", Random.Range(4f, 8f));
    }
}
