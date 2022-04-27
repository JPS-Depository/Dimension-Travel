using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using DigitalRuby.SimpleLUT;


public class Settings : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Camera mainCamera;
    

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetBrightness(float brightness)
    {
        mainCamera.GetComponent<SimpleLUT>().Brightness = brightness;
    }
}
