using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RevealImage : MonoBehaviour
{
    Image image;
    Color color;

    private void Start()
    {
        image = GetComponent<Image>();
        color = image.color;

        color.a = 1;
        image.color = color;
    }

    public float targetTime;
    private float targetTime2 = 0.1f;

    void Update()
    {
        targetTime -= Time.deltaTime;

        if (targetTime <= 2.0f)
        {
            targetTime2 -= Time.deltaTime;

            if (targetTime2 <= 0.0f)
            {
                color.a -= 0.05f;
                image.color = color;

                targetTime2 = 0.1f;
            }
        }

        if (color.a <= 0)
        {
            image.enabled = false;
            //Debug.Log("Image inactive here");
        }
    }
}
