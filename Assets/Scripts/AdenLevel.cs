using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdenLevel : MonoBehaviour
{
    public int button;
    public Text dialogue;
    public Image customer;
    public Text moneyText;
    public void ChangeDialogue()
    {
        Debug.Log("cnt start: " + AdenLevelPlayer.cnt);
        Debug.Log("button: " + button);

        if (AdenLevelPlayer.cnt == 0)
        {
            dialogue.text = "H-Hello. Can I have a nice bath please? (This is a young spirit. You know their parents, and you know they have not given them a bath in weeks.)";
            customer.sprite = Resources.Load<Sprite>("duck");

            if (button == 0)
            {
                if (AdenLevelPlayer.money >= 50)
                {
                    AdenLevelPlayer.money -= 50;
                    AdenLevelPlayer.cnt = 1;
                } else
                {
                    end(0);
                }
            } else if (button == 1)
            {
                if (AdenLevelPlayer.money >= 100)
                {
                    AdenLevelPlayer.money -= 100;
                    AdenLevelPlayer.cnt = 1;
                } else
                {
                    dialogue.text = "You cannot afford them a nice bath.";
                    customer.sprite = Resources.Load<Sprite>("frog");
                }
            }
            moneyText.text = "$" + AdenLevelPlayer.money;
        } else if (AdenLevelPlayer.cnt == 1)
        {
            dialogue.text = "I’d like a very deep clean please in your biggest bath. (You remember this spirit being in here just yesterday.)";
            customer.sprite = Resources.Load<Sprite>("radishBoy");

            if (button == 0)
            {
                if (AdenLevelPlayer.money >= 50)
                {
                    AdenLevelPlayer.money -= 50;
                    AdenLevelPlayer.cnt = 2;
                } else
                {
                    end(0);
                }
            }
            else if (button == 1)
            {
                if (AdenLevelPlayer.money >= 100)
                {
                    AdenLevelPlayer.money -= 100;
                    AdenLevelPlayer.points += 1;
                    AdenLevelPlayer.cnt = 2;
                } else
                {
                    dialogue.text = "You cannot afford them a nice bath.";
                    customer.sprite = Resources.Load<Sprite>("duck");
                }
            }
            moneyText.text = "$" + AdenLevelPlayer.money;
        } else if (AdenLevelPlayer.cnt == 2)
        {
            dialogue.text = "Can I please have a nicer bath? I just ate ramen and I STINK! I want to scrub the smell out!";
            customer.sprite = Resources.Load<Sprite>("drippy");

            if (button == 0)
            {
                if (AdenLevelPlayer.money >= 50)
                {
                    AdenLevelPlayer.money -= 50;
                    AdenLevelPlayer.cnt = 3;
                } else
                {
                    end(0);
                }
            }
            else if (button == 1)
            {
                if (AdenLevelPlayer.money >= 100)
                {
                    AdenLevelPlayer.money -= 100;
                    AdenLevelPlayer.points += 0.5f;
                    AdenLevelPlayer.cnt = 3;
                } else
                {
                    dialogue.text = "You cannot afford them a nice bath.";
                    customer.sprite = Resources.Load<Sprite>("radishBoy");
                }
            }
            moneyText.text = "$" + AdenLevelPlayer.money;
        } else if (AdenLevelPlayer.cnt == 3)
        {
            dialogue.text = "I just got off of a multiple day shift and would love a soothing deep clean… Please give me a nice bath. (You know this spirit and know they have a bath in their room.)";
            customer.sprite = Resources.Load<Sprite>("boh2");

            if (button == 0)
            {
                if (AdenLevelPlayer.money >= 50)
                {
                    AdenLevelPlayer.money -= 50;
                    AdenLevelPlayer.cnt = 4;
                } else
                {
                    end(0);
                }
            }
            else if (button == 1)
            {
                if (AdenLevelPlayer.money >= 100)
                {
                    AdenLevelPlayer.money -= 100;
                    AdenLevelPlayer.cnt = 4;
                } else
                {
                    dialogue.text = "You cannot afford them a nice bath.";
                    customer.sprite = Resources.Load<Sprite>("drippy");
                }
            }
            moneyText.text = "$" + AdenLevelPlayer.money;
        } else if (AdenLevelPlayer.cnt == 4)
        {
            dialogue.text = "Give me a nice bath or else.";
            customer.sprite = Resources.Load<Sprite>("noface");

            if (button == 0)
            {
                if (AdenLevelPlayer.money >= 50)
                {
                    AdenLevelPlayer.money -= 50;
                    AdenLevelPlayer.cnt = 5;
                } else
                {
                    end(0);
                }
            }
            else if (button == 1)
            {
                if (AdenLevelPlayer.money >= 100)
                {
                    AdenLevelPlayer.money -= 100;
                    AdenLevelPlayer.points += 0.5f;
                    AdenLevelPlayer.cnt = 5;
                } else
                {
                    dialogue.text = "You cannot afford them a nice bath.";
                    customer.sprite = Resources.Load<Sprite>("boh2");
                }
            }
            moneyText.text = "$" + AdenLevelPlayer.money;
        } else if (AdenLevelPlayer.cnt == 5)
        {
            dialogue.text = "Hello, dear. Can I please have a nice, steamy bath to loosen up my achy joints?";
            customer.sprite = Resources.Load<Sprite>("oldLady");

            if (button == 0)
            {
                if (AdenLevelPlayer.money >= 200)
                {
                    AdenLevelPlayer.money -= 200;
                    AdenLevelPlayer.cnt = 6;
                } else
                {
                    AdenLevelPlayer.money = 0;
                    end(0);
                }
            }
            else if (button == 1)
            {
                if (AdenLevelPlayer.money >= 100)
                {
                    AdenLevelPlayer.money -= 100;
                    AdenLevelPlayer.points += 0.5f;
                    AdenLevelPlayer.cnt = 6;
                } else
                {
                    dialogue.text = "You cannot afford them a nice bath.";
                    customer.sprite = Resources.Load<Sprite>("noface");
                }
            }
            moneyText.text = "$" + AdenLevelPlayer.money;
        } else if (AdenLevelPlayer.cnt == 6)
        {
            if (button == 0)
            {
                if (AdenLevelPlayer.money >= 50)
                {
                    AdenLevelPlayer.money -= 50;
                    end(1);
                } else
                {
                    end(0);
                }
            }
            else if (button == 1)
            {
                if (AdenLevelPlayer.money >= 100)
                {
                    AdenLevelPlayer.money -= 100;
                    AdenLevelPlayer.points += 1;
                    end(1);
                } else
                {
                    dialogue.text = "You cannot afford them a nice bath.";
                }
            }
            moneyText.text = "$" + AdenLevelPlayer.money;
        }

        Debug.Log("cnt end: " + AdenLevelPlayer.cnt);
        Debug.Log("points: " + AdenLevelPlayer.points);
    }

    public void end(int ending)
    {
        AdenLevelPlayer.cnt = 0;

        if (ending == 0)
        {
            dialogue.text = "It seems you have ran out of money. We shall see how moral your judgement was.";
            customer.sprite = Resources.Load<Sprite>("transparent");
        } else if (ending == 1)
        {
            dialogue.text = "It seems you have ran out of customers. We shall see how moral your judgement was.";
            customer.sprite = Resources.Load<Sprite>("transparent");
        }

        // GO TO NEXT SCENE
    }
}
