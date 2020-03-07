using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosserSpawnScript : MonoBehaviour
{
    public GameObject crosser;
    private int crosserLimit = 4;
    private float respawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        respawnTimer = Random.Range(1.0f, 3.0f);
    }

    void SpawnCrosser()
    {
        float randomPos = Random.Range(-5.0f, 5.0f);
        Instantiate(crosser, new Vector3(transform.position.x, transform.position.y, transform.position.z + randomPos), crosser.transform.rotation);
        respawnTimer = Random.Range(3.0f, 5.0f);;
    }

    // Update is called once per frame
    void Update()
    {
        int spawned = GameObject.FindGameObjectsWithTag("Crosser").Length;

        if (spawned < crosserLimit) {
            respawnTimer -= Time.deltaTime;
        } else {
            respawnTimer -= Time.deltaTime / 2;
        }
 
         if (respawnTimer <= 0.0f) {
            Debug.Log("Spawned so far = " + spawned);
            SpawnCrosser();
         }
    }
}
