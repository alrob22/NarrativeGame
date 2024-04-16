using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenController : MonoBehaviour
{
    public SenGameController gameController;
    public GameObject Dumpling;
    public GameObject Spirit;
    public GameObject Wall;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnDumpling", 10.0f, 10.0f);
        InvokeRepeating("SpawnSpirit", 5.0f, 5.0f);
        InvokeRepeating("SpawnWall", 4.0f, 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnDumpling()
    {
        Instantiate(Dumpling, transform.position, Quaternion.identity);
    }
    void SpawnSpirit()
    {
        Instantiate(Spirit, transform.position, Quaternion.identity);
    }
    void SpawnWall()
    {
        Instantiate(Wall, transform.position, Quaternion.identity);
    }
}
