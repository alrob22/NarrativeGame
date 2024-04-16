using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdenLevel : MonoBehaviour
{
    private static bool go = true;
    private static int cnt = 0;
    private static int money = 550;
    private static float points = 0;

    public int button;
    public Text dialogue;
    public Image customer;
    public Text moneyText;

    public void ChangeDialogue()
    {
        Debug.Log("cnt start: " + cnt);
        Debug.Log("button: " + button);

        if (go)
        {
            if (cnt == 0)
            {
                dialogue.text = "H-Hello. Can I have a nice bath please? (This is a young spirit. You know their parents, and you know they have not given them a bath in weeks.)";
                customer.sprite = Resources.Load<Sprite>("duck");

                if (button == 0)
                {
                    if (money >= 50)
                    {
                        money -= 50;
                        cnt = 1;
                    }
                    else
                    {
                        end(0);
                    }
                }
                else if (button == 1)
                {
                    if (money >= 100)
                    {
                        money -= 100;
                        cnt = 1;
                    }
                    else
                    {
                        dialogue.text = "You cannot afford them a nice bath.";
                        customer.sprite = Resources.Load<Sprite>("frog");
                    }
                }
                moneyText.text = "$" + money;
            }
            else if (cnt == 1)
            {
                dialogue.text = "I’d like a very deep clean please in your biggest bath. (You remember this spirit being in here just yesterday.)";
                customer.sprite = Resources.Load<Sprite>("radishBoy");

                if (button == 0)
                {
                    if (money >= 50)
                    {
                        money -= 50;
                        cnt = 2;
                    }
                    else
                    {
                        end(0);
                    }
                }
                else if (button == 1)
                {
                    if (money >= 100)
                    {
                        money -= 100;
                        points += 1;
                        cnt = 2;
                    }
                    else
                    {
                        dialogue.text = "You cannot afford them a nice bath.";
                        customer.sprite = Resources.Load<Sprite>("duck");
                    }
                }
                moneyText.text = "$" + money;
            }
            else if (cnt == 2)
            {
                dialogue.text = "Can I please have a nicer bath? I just ate ramen and I STINK! I want to scrub the smell out!";
                customer.sprite = Resources.Load<Sprite>("drippy");

                if (button == 0)
                {
                    if (money >= 50)
                    {
                        money -= 50;
                        cnt = 3;
                    }
                    else
                    {
                        end(0);
                    }
                }
                else if (button == 1)
                {
                    if (money >= 100)
                    {
                        money -= 100;
                        points += 0.5f;
                        cnt = 3;
                    }
                    else
                    {
                        dialogue.text = "You cannot afford them a nice bath.";
                        customer.sprite = Resources.Load<Sprite>("radishBoy");
                    }
                }
                moneyText.text = "$" + money;
            }
            else if (cnt == 3)
            {
                dialogue.text = "I just got off of a multiple day shift and would love a soothing deep clean… Please give me a nice bath. (You know this spirit and know they have a bath in their room.)";
                customer.sprite = Resources.Load<Sprite>("boh2");

                if (button == 0)
                {
                    if (money >= 50)
                    {
                        money -= 50;
                        cnt = 4;
                    }
                    else
                    {
                        end(0);
                    }
                }
                else if (button == 1)
                {
                    if (money >= 100)
                    {
                        money -= 100;
                        cnt = 4;
                    }
                    else
                    {
                        dialogue.text = "You cannot afford them a nice bath.";
                        customer.sprite = Resources.Load<Sprite>("drippy");
                    }
                }
                moneyText.text = "$" + money;
            }
            else if (cnt == 4)
            {
                dialogue.text = "Give me a nice bath or else.";
                customer.sprite = Resources.Load<Sprite>("noface");

                if (button == 0)
                {
                    if (money >= 50)
                    {
                        money -= 50;
                        cnt = 5;
                    }
                    else
                    {
                        end(0);
                    }
                }
                else if (button == 1)
                {
                    if (money >= 100)
                    {
                        money -= 100;
                        points += 0.5f;
                        cnt = 5;
                    }
                    else
                    {
                        dialogue.text = "You cannot afford them a nice bath.";
                        customer.sprite = Resources.Load<Sprite>("boh2");
                    }
                }
                moneyText.text = "$" + money;
            }
            else if (cnt == 5)
            {
                dialogue.text = "Hello, dear. Can I please have a nice, steamy bath to loosen up my achy joints?";
                customer.sprite = Resources.Load<Sprite>("oldLady");

                if (button == 0)
                {
                    if (money >= 200)
                    {
                        money -= 200;
                        cnt = 6;
                    }
                    else
                    {
                        money = 0;
                        end(0);
                    }
                }
                else if (button == 1)
                {
                    if (money >= 100)
                    {
                        money -= 100;
                        points += 0.5f;
                        cnt = 6;
                    }
                    else
                    {
                        dialogue.text = "You cannot afford them a nice bath.";
                        customer.sprite = Resources.Load<Sprite>("noface");
                    }
                }
                moneyText.text = "$" + money;
            }
            else if (cnt == 6)
            {
                if (button == 0)
                {
                    if (money >= 50)
                    {
                        money -= 50;
                        end(1);
                    }
                    else
                    {
                        end(0);
                    }
                }
                else if (button == 1)
                {
                    if (money >= 100)
                    {
                        money -= 100;
                        points += 1;
                        end(1);
                    }
                    else
                    {
                        dialogue.text = "You cannot afford them a nice bath.";
                    }
                }
                moneyText.text = "$" + money;
            }
        }

        Debug.Log("cnt end: " + cnt);
        Debug.Log("points: " + points);
    }

    public void end(int ending)
    {
        cnt = 0;
        go = false;

        if (ending == 0)
        {
            dialogue.text = "It seems you have ran out of money. We shall see how moral your judgement was.";
            customer.sprite = Resources.Load<Sprite>("transparent");
        } else if (ending == 1)
        {
            dialogue.text = "It seems you have ran out of customers. We shall see how moral your judgement was.";
            customer.sprite = Resources.Load<Sprite>("transparent");
        }

        // GO TO NEXT SCENE- 3.5 points for good :)
    }
}
