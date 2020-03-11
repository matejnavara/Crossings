using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    public float speed = 10.0f;
    public BeepScript beep;

    private GameManager gm;
    private float modifier = 1f;

    void Start()
    {
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        beep = transform.Find("Beep").GetComponent<BeepScript>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Car") {
            speed = Mathf.Min(col.gameObject.GetComponentInParent<CarScript>().speed, speed);
            beep.RandomBeep();
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
