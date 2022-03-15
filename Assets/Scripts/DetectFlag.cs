using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectFlag : MonoBehaviour
{
    public AudioSource cheerAudio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) 
    {
        cheerAudio.Play();
    }
}
