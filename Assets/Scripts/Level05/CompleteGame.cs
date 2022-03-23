using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteGame : MonoBehaviour
{
    private string endPointTag = "EndPoint";
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
        if (other.tag == endPointTag && !isTriggered)
        {
            Debug.Log("ended game!");
            isTriggered = true;
        }
    }
}
