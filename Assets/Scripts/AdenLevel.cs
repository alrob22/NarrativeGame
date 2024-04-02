using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdenLevel : MonoBehaviour
{
    public Text dialogue;
    public Image customer;
    private int cnt;
    public void ChangeDialogue()
    {
        if (cnt == 0)
        {
            dialogue.text = "H-Hello. Can I have a nice bath please? (This is a young spirit. You know their parents, and you know they have not given them a bath in weeks.)";
            Sprite newSprite = Resources.Load<Sprite>("duck");
            customer.sprite = newSprite;
            cnt++;
        } else if (cnt == 1)
        {
            cnt++;
        } else if (cnt == 2)
        {
            cnt++;
        } else if (cnt == 3)
        {
            cnt++;
        } else if (cnt == 4)
        {
            cnt++;
        } else if (cnt == 5)
        {
            cnt++;
        } else if (cnt == 6)
        {
            cnt = 0;
        }
    }

    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    //void Update()
    //{
        
    //}
}
