using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float moveSpeed;
    public int patrolDestination;

    // Update is called once per frame
    void Update()
    {
        if (patrolDestination == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[patrolDestination].position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPoints[patrolDestination].position) < 0.2f)
            {
                patrolDestination = 1;
            }
        } else
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[patrolDestination].position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPoints[patrolDestination].position) < 0.2f)
            {
                patrolDestination = 0;
            }

        }
        
    }
}
