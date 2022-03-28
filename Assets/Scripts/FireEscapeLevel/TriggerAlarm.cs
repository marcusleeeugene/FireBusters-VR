using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAlarm : MonoBehaviour
{
    public AudioSource fireAlarm;
    public AudioSource broadcast;
    private string handTag = "Hand";
    private bool isTriggered = false;

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
        if (other.tag == handTag && !isTriggered)
        {
            fireAlarm.Play();
            broadcast.Play();
            isTriggered = true;
            LevelStateManager.isTriggerAlarm = true;
        }
    }
}
