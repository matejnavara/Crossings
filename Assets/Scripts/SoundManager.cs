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

        public void PlayGameOver()
        {
            efxSource.clip = gameOver;
            efxSource.Play();
        }

    }