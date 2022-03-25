using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitDoor : MonoBehaviour
{
    private string handTag = "Hand";
    private bool isTriggered = false;
    public GameObject cameraRig;
    public AudioSource openDoorAudio;
    public Text alarmNotTriggerMsg;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(LevelStateManager.isTriggerAlarm) {
            alarmNotTriggerMsg.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == handTag && !isTriggered)
        {
            if(!LevelStateManager.isTriggerAlarm)
            {
                alarmNotTriggerMsg.gameObject.SetActive(true);
            } else {
                cameraRig.transform.Translate(Vector3.forward * 2);
                openDoorAudio.Play();
                isTriggered = true;
            }
        }
    }
}
