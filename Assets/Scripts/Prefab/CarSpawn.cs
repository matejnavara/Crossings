using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawn : MonoBehaviour
{
    public GameObject[] cars;
    
    private GameManager gm;
    private float respawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        respawnTimer = Random.Range(1.0f, 3.0f);
    }

    void SpawnCar()
    {
        int randomCar = Random.Range(0,20);
        if (gm.getRushHour())
        {
            respawnTimer = Random.Range(1.0f, 3.0f);
        } else {
            respawnTimer = Random.Range(3.0f, 10.0f);
        }
        Instantiate(cars[randomCar], transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        respawnTimer -= Time.deltaTime;
 
         if (respawnTimer <= 0.0f) {
            SpawnCar();
         }
    }
}
