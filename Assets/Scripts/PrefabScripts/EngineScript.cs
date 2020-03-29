using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineScript : MonoBehaviour
{
    public AudioSource efxSource;                    //Drag a reference to the audio source which will play the sound effects.
    public AudioClip[] engineClips;                    //Drag a reference to the audio source which will play the music.
    public float lowPitchRange = .95f;                //The lowest a sound effect will be randomly pitched.
    public float highPitchRange = 1.05f;            //The highest a sound effect will be randomly pitched.

    void Start()
    {
        efxSource = GetComponent<AudioSource>();
        //Generate a random number between 0 and the length of our array of clips passed in.
        int randomIndex = Random.Range(0, engineClips.Length);

        //Choose a random pitch to play back our clip at between our high and low pitch ranges.
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);

        //Set the pitch of the audio source to the randomly chosen pitch.
        efxSource.pitch = randomPitch;

        //Set the clip to the clip at our randomly chosen index.
        efxSource.clip = engineClips[randomIndex];

        //Play the clip.
        efxSource.Play();
    }
}
