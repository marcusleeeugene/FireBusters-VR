using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
    private AudioSource[] AudioSources;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AudioSources = FindObjectsOfType<AudioSource>();
        foreach(AudioSource audioSource in AudioSources){
            audioSource.volume = PlayerPrefs.GetFloat("SoundVolume");
        }
        AudioListener.volume = PlayerPrefs.GetFloat("SoundVolume");
        
    }
}
