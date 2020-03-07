using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosserScript : MonoBehaviour
{
    public bool isWaiting = false;
    private GameManager gm;

    void Start()
    {
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Colliding: " + col.tag);
        if (col.tag == "WaitZone")
        {
            isWaiting = true;
        };

        if (col.tag == "Finish")
        {
            gm.SuccessfulCrossing();
            Destroy(gameObject);
        }
    }

    void OnTriggerExit(Collider col)
    {
        Debug.Log("Not colliding: " + col.tag);
        if (col.tag == "WaitZone")
        {
            isWaiting = false;
        };
    }

    void Update()
    {
        if (!isWaiting) transform.position += transform.right * Time.deltaTime * 5;
    }

}
