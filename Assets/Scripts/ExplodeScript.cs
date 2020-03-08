using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeScript : MonoBehaviour
{
    public AudioClip[] explodeClips;
    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        int random = Random.Range(0, explodeClips.Length);
        AudioClip clip = explodeClips[random];
        audio = GetComponent<AudioSource>();
        audio.clip = clip;
        audio.Play();
    }
}
