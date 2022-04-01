using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDoor : MonoBehaviour
{
    private string handTag = "Hand";
    public GameObject cameraRig;
    public AudioSource openDoorAudio;

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
        if (other.tag == handTag)
        {
            cameraRig.transform.Translate(Vector3.forward * 2);
            openDoorAudio.Play();
        }
    }
}
