using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
 
        public AudioClip SoundToPlay;
        public float Volume;
        AudioSource audio;
        public bool alreadyPlayed = false;


        // Start is called before the first frame update
        void Start()
        {
            audio = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnTriggerEnter(Collider other)
        {
            if (!alreadyPlayed)
            {
                audio.PlayOneShot(SoundToPlay, Volume);
                alreadyPlayed = true;
            }
        }
    
}
