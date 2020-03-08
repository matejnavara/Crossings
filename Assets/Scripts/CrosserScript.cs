using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosserScript : MonoBehaviour
{
    public bool isWaiting = false;
    public GameObject explodeParticles;
    private GameManager gm;
    private Animator anim;

    void Start()
    {
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        anim = GetComponent<Animator> ();
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Colliding: " + col.tag);
        if (col.tag == "WaitZone")
        {
            isWaiting = true;
            anim.Play("Waiting", 0, Random.Range(0f, 1f));
            // anim.SetBool("isWaiting", true);
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
            anim.Play("Walking", 0, Random.Range(0f, 1f));
            //anim.SetBool("isWaiting", false);
        };
    }

    void Update()
    {
        if (!isWaiting) transform.position += transform.right * Time.deltaTime * 5;
    }

}
