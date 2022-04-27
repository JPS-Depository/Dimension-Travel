using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    public static AudioClip gasSound, breaksSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        gasSound = Resources.Load<AudioClip>("gas");
        breaksSound = Resources.Load<AudioClip>("breaks");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch(clip)
        {
            case "gas":
                audioSrc.PlayOneShot(gasSound);
                break;
            case "breaks":
                audioSrc.PlayOneShot(breaksSound);
                break;
        }
    }
}
