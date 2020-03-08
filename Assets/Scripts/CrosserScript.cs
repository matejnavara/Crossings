using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosserScript : MonoBehaviour
{
    public bool isWaiting = false;
    public GameObject explodeParticles;

    public bool returnJourney = false;
    private GameManager gm;
    private Animator anim;
    private float speed;

    void Start()
    {
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        anim = GetComponentInChildren<Animator> ();
        speed = Random.Range(3.0f, 6.0f);
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Colliding: " + col.tag);
        if (col.tag == "WaitZone")
        {
            isWaiting = true;
            anim.Play("Waiting", 0, Random.Range(0f, 0.75f));
        };

        if (col.tag == "Finish")
        {
            gm.SuccessfulCrossing();
            Destroy(gameObject);
        }

        if (col.tag == "Car")
        {
            gm.UnsuccessfulCrossing();
            GameObject explode = Instantiate(explodeParticles, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void OnTriggerExit(Collider col)
    {
        Debug.Log("Not colliding: " + col.tag);
        if (col.tag == "WaitZone")
        {
            isWaiting = false;
            anim.Play("Walking", 0, Random.Range(0f, 0.75f));
        };
    }

    void Update()
    {
        if (!isWaiting) transform.position += transform.forward * Time.deltaTime * speed;
    }

}
