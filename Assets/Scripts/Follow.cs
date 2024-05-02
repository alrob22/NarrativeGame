using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Follow : MonoBehaviour
{

    public GameObject player;
    public float speed;

    public GameObject goal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //only if player is in Haku form
        if (ChangeSprite.currSprite == 0)
        {
            Vector2 direction = player.transform.position - transform.position;
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed + Time.deltaTime);
        }
        

        //check if at end point (range) , trigger end game
        if (Vector3.Distance(transform.position, goal.transform.position) <= 2)
        {
            //update points
            //have a static variable in haku's script, decrement by 1 every time you run into an object
            Player.totalPoints += 1;

            //transition to next scene
            SceneManager.LoadScene("TrainInside2");
        }
        
    }
}
