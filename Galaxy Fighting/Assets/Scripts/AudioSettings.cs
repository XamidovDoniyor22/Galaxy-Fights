using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    private AudioSource audioSource;
    private float musicVolume = 1f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        audioSource.volume = musicVolume;   
    }
    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }

}
