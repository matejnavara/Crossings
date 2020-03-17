using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawn : MonoBehaviour
{
    public GameObject[] normalCars;
    public GameObject[] emergencyCars;
    
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
        if (gm.getRushHour())
        {
            SelectSpawn(0.8f);
            respawnTimer = Random.Range(1.0f, 3.0f);
        } else {
            SelectSpawn(0.95f);
            respawnTimer = Random.Range(3.0f, 10.0f);
        }
    }

    void SelectSpawn(float threshold)
    {
        float emergencyChance = Random.Range(0f, 1f);
        if (emergencyChance > threshold) {
            Debug.Log("EMERGENCY: " + emergencyChance);
            SpawnEmergencyCar();
        } else {
            SpawnNormalCar();
        }
    }

    void SpawnNormalCar()
    {
        int randomCar = Random.Range(0, normalCars.Length);
        Instantiate(normalCars[randomCar], transform.position, transform.rotation);
    }

    void SpawnEmergencyCar()
    {
        int randomCar = Random.Range(0, emergencyCars.Length);
        Instantiate(emergencyCars[randomCar], transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        respawnTimer -= Time.deltaTime;
 
         if (!gm.getGameOver() && respawnTimer <= 0.0f) {
            SpawnCar();
         }
    }
}
