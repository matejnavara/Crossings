using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    public float speed = 10.0f;

    void OnTriggerEnter(Collider col)
    {
            Debug.Log("Collide of " + gameObject.name + " and " + col.name);
            speed = col.gameObject.GetComponentInParent<CarScript>().speed;
            Debug.Log("New speed = " + speed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }
}
