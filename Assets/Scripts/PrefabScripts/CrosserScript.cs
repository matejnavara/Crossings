﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosserScript : MonoBehaviour
{
    public bool isWaiting = false;
    public GameObject explodeParticles;
    public AudioClip[] introClips;

    public bool returnJourney = false;
    private GameManager gm;
    private Animator anim;
    private AudioSource audio;
    private float speed;
    private float modifier = 1f;

    void Start()
    {
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        anim = GetComponentInChildren<Animator> ();
        speed = Random.Range(3.0f, 6.0f);
        StartAudio();
    }

    void StartAudio()
    {
        int random = Random.Range(0, introClips.Length);
        AudioClip clip = introClips[random];
        audio = GetComponent<AudioSource>();
        audio.clip = clip;
        audio.Play();
    }

    void OnTriggerEnter(Collider col)
    {
        if ((!returnJourney && col.tag == "WaitZone") || (returnJourney && col.tag == "ReturnWaitZone"))
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
        if (col.tag == "WaitZone" || col.tag == "ReturnWaitZone")
        {
            isWaiting = false;
            anim.Play("Walking", 0, Random.Range(0f, 0.75f));
        };
    }

    void Update()
    {
        if (gm.getRushHour()) modifier = 2f;
        if (!isWaiting) transform.position += transform.forward * Time.deltaTime * speed * modifier;
    }

}
