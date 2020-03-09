using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScript : MonoBehaviour
{
    public CrosserSpawn crosserSpawn;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Crosser")
        {
            crosserSpawn.ReturnedCrosser();
        }
    }
}
