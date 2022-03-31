using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnPortal : MonoBehaviour
{
    private string handTag = "Hand";
    public GameObject cameraRig;
    private AudioSource openDoorAudio;
    private string startingScene = "Start Point";

    // Start is called before the first frame update
    void Start()
    {
       openDoorAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == handTag)
        {
            Debug.Log("touch door");
            cameraRig.transform.Translate(Vector3.forward * 2);
            openDoorAudio.Play();
            SceneManager.LoadScene(startingScene);
        }
    }
}
