using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawnScript : MonoBehaviour
{
    public GameObject[] cars;
    
    private float respawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        respawnTimer = Random.Range(1.0f, 3.0f);
    }

    void SpawnCar()
    {
        int randomCar = Random.Range(0,20);
        Instantiate(cars[randomCar], transform.position, transform.rotation);
        respawnTimer = Random.Range(3.0f, 10.0f);;
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
