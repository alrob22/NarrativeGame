using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{

    public Sprite sp1, sp2;
    public static int currSprite = 0;
    public GameObject enemy0;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;

    // Start is called before the first frame update
    void Start()
    {
        currSprite = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)) {
            if (GetComponent<SpriteRenderer>().sprite == sp1)
            {
                GetComponent<SpriteRenderer>().sprite = sp2;
                currSprite = 1;
                transform.localScale = new Vector3(.8f, .8f, 1);
            } else
            {
                GetComponent<SpriteRenderer>().sprite = sp1;
                currSprite = 0;
                transform.localScale = new Vector3(2f, 2f, 1);
            }
        }


        //check if hit enemies
        if (Vector2.Distance(transform.position, enemy0.transform.position) <= 1.5f)
        {
            //if haku form (move this chunk into changesprite script)
            if (currSprite == 0)
            {
                transform.position = new Vector3(6.91f, 7.8f, -1f);

            } else
            {
                Destroy(enemy0);
            }
        }
        if (Vector2.Distance(transform.position, enemy1.transform.position) <= 1.5f)
        {
            if (currSprite == 0)
            {
                transform.position = new Vector3(6.91f, 7.8f, -1f);

            }
            else
            {
                Destroy(enemy1);
            }
        }
        if (Vector2.Distance(transform.position, enemy2.transform.position) <= 3f)
        {
            if (currSprite == 0)
            {
                transform.position = new Vector3(6.91f, 7.8f, -1f);

            }
            else
            {
                Destroy(enemy2);
            }
        }
        if (Vector2.Distance(transform.position, enemy3.transform.position) <= 1.5f)
        {
            if (currSprite == 0)
            {
                transform.position = new Vector3(6.91f, 7.8f, -1f);

            }
            else
            {
                Destroy(enemy3);
            }
        }
        if (Vector2.Distance(transform.position, enemy4.transform.position) <= 2f)
        {
            if (currSprite == 0)
            {
                transform.position = new Vector3(6.91f, 7.8f, -1f);

            }
            else
            {
                Destroy(enemy4);
            }
        }
    }
}
