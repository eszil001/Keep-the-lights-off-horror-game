using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{

    public AudioSource SoundToPlay;
   
    
    // Start is called before the first frame update
    void Start()
    {
        SoundToPlay = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            SoundToPlay.Play();
            Destroy(collision.gameObject);

        }
    }


    /*
    void OnTriggerEnter(Collider other)
    {
        if (!alreadyPlayed)
        {
            audio.PlayOneShot(SoundToPlay, Volume);
            alreadyPlayed = true;
        }
    }
    */
}