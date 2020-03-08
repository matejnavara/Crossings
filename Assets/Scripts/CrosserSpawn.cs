using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosserSpawn : MonoBehaviour
{
    public GameObject crosser;
    public int crosserPopulation;
    public bool returnSpawner;
    private float respawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        respawnTimer = Random.Range(1.0f, 3.0f);
    }

    public void ReturnedCrosser()
    {
        crosserPopulation += 1;
    }

    void SpawnCrosser()
    {
        float randomPos = Random.Range(-7.0f, 7.0f);
        GameObject newCrosser = Instantiate(crosser, new Vector3(transform.position.x, transform.position.y, transform.position.z + randomPos), transform.rotation);
        if (returnSpawner) newCrosser.GetComponent<CrosserScript>().returnJourney = true;
        respawnTimer = Random.Range(0.2f, 2.0f);
        crosserPopulation -= 1;
    }

    // Update is called once per frame
    void Update()
    {
        respawnTimer -= Time.deltaTime;
 
         if (crosserPopulation > 0 && respawnTimer <= 0.0f) {
            SpawnCrosser();
         }
    }
}
