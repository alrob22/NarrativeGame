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
        transform.Translate(Vector2.left * Time.deltaTime * gameController.runSpeed);
        if (transform.position.x < -9.5)
        {
            Destroy(this.gameObject);
        }
    }
}
