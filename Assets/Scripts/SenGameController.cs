using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SenGameController : MonoBehaviour
{
    public bool coinDown;
    public float runSpeed;
    public float vertSpeed;
    public float UpLimit;
    public float DownLimit;
    public int spiritsEaten = 0;
    [SerializeField] private Image[] SpiritSprites;
    public int spiritsSaved = 0;

    [SerializeField] private int timeLimit;
    [SerializeField] private TMP_Text timer;
    [SerializeField] private int dumplingCount;
    [SerializeField] private Image[] DumplingSprites;
    public GameObject Coin;
    public Animator NoAnim;

    // Start is called before the first frame update
    void Start()
    {
        coinDown = true;
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
        if (Input.GetKeyDown(KeyCode.Space) && coinDown)
        {
            Instantiate(Coin, transform.position, Quaternion.identity);
            coinDown = false;
            Invoke("CoinFired", 1.5f);
        }
        if (dumplingCount == 5)
        {
            // scene transition
            Invoke("End", 0f);
        }
        if (spiritsEaten == 5)
        {
            // scene transition
            Invoke("End", 0f);
        }
        if (timeLimit <= 0)
        {
            // scene transition
            Invoke("End", 0f);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Dumpling"))
        {
            Destroy(col.gameObject);
            NoAnim.SetTrigger("Eat");
            DumplingSprites[dumplingCount].enabled = true;
            dumplingCount++;
        }
        else if (col.gameObject.CompareTag("Spirit"))
        {
            timeLimit += 10;
            timer.text = timeLimit.ToString();
            timer.color = Color.green;
            Invoke("TurnWhite", 1f);
            NoAnim.SetTrigger("Eat");
            SpiritSprites[spiritsEaten].enabled = true;
            SpiritSprites[spiritsEaten].sprite = col.gameObject.GetComponent<SpiritController>().sprites[col.gameObject.GetComponent<SpiritController>().SpiritType - 1];
            spiritsEaten++;
            Destroy(col.gameObject);
        }
        else if (col.gameObject.CompareTag("Wall"))
        {
            Destroy(col.gameObject);
            timeLimit -= 10;
            timer.text = timeLimit.ToString();
            timer.color = Color.red;
            Invoke("TurnWhite", 1f);
        }
    }

    void timerCountDown()
    {
        timeLimit--;
        timer.text = timeLimit.ToString();
    }
    void TurnWhite()
    {
        timer.color = Color.white;
    }
    void CoinFired()
    {
        coinDown = true;
    }
    void End()
    {
        Player.totalPoints += spiritsSaved;
        Player.totalPoints -= spiritsEaten;
        SceneManager.LoadScene("TrainInside2 1"); // Change this scene
        Debug.Log("total points: " + Player.totalPoints);
    }
}
