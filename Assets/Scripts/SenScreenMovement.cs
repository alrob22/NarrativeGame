using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenScreenMovement : MonoBehaviour
{
    public float LeftLimit;
    public float RightStart;
    public SenGameController gameController;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * gameController.runSpeed);
        if (transform.position.x < LeftLimit)
        {
            transform.position = new Vector2(RightStart, 0);
        }
    }
}
