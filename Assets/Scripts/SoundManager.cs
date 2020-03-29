using UnityEngine;
using System.Collections;

    public class SoundManager : MonoBehaviour 
    {
        public AudioClip gameLoop;
        public AudioClip gameOver;
        public AudioClip gameOverLoop;

        private AudioSource efxSource;

        void Start()
        {
            efxSource = GetComponent<AudioSource>();
        }

        public void PlayTheme()
        {
            efxSource.clip = gameLoop;
            efxSource.Play();
        }

        public void RushHour()
        {
            efxSource.pitch = 1.5f;
        }

        public void PlayGameOver()
        {
            efxSource.Stop();
            efxSource.pitch = 1.0f;
            efxSource.PlayOneShot(gameOver);
            efxSource.clip = gameOverLoop;
            efxSource.Play();
        }

    }