using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Note : MonoBehaviour
{
    public Image noteImage;
    public AudioClip pickupSound;
    public AudioClip putawaySound;
    public GameObject ThePlayer;

    public float TheDistance;



    // Start is called before the first frame update
    void Start()
    {
       noteImage.enabled = false;
    }

    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }


    public void ShowNoteImage()
    {

        if(TheDistance <= 5)
        {

            if (Input.GetButtonDown("N"))
            {
                noteImage.enabled = true;
                GetComponent<AudioSource>().PlayOneShot(pickupSound);

                ThePlayer.GetComponent<FirstPersonController>().enabled = false;
            }
        }
    }

    public void HideNoteImage()
    {
        //  noteImage.enabled = false;
        if (TheDistance <= 5)
        {
            if (Input.GetButtonDown("Cancel") && noteImage.enabled == true)
            {
                HideNoteImage();
                GetComponent<AudioSource>().PlayOneShot(putawaySound);
                ThePlayer.GetComponent<FirstPersonController>().enabled = true;
            }
        }

    }
   
}
