using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    public float speed = 10.0f;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Car") {
            speed = Mathf.Min(col.gameObject.GetComponentInParent<CarScript>().speed, speed);
        };
        if (col.tag == "Despawn") {
            Destroy(gameObject);
        };
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }
}
