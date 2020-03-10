using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    public float speed = 10.0f;

    private GameManager gm;
    private float modifier = 1f;

    void Start()
    {
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

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
        if (gm.getRushHour()) modifier = 2f;
        transform.position += transform.forward * Time.deltaTime * speed * modifier;
    }
}
