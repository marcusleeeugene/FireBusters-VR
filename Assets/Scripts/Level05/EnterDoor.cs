using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDoor : MonoBehaviour
{
    private string handTag = "Hand";
    private bool isTriggered = false;
    public GameObject cameraRig;

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
            cameraRig.transform.Translate(Vector3.forward * 2);
            isTriggered = true;
        }
    }
}
