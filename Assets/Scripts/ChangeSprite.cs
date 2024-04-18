using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{

    public Sprite sp1, sp2;
    public static int currSprite = 0;

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
                transform.localScale = new Vector3(.4f, .4f, 1);
            } else
            {
                GetComponent<SpriteRenderer>().sprite = sp1;
                currSprite = 0;
                transform.localScale = new Vector3(.6f, .6f, 1);
            }
        }
    }
}
