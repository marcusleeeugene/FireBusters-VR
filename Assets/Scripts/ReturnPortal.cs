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
    private int numberOfCorrectObjects = 0;
    private Outline outline;
    private bool isLevelClear;


    // Start is called before the first frame update
    void Start()
    {
        outline = gameObject.AddComponent<Outline>();
        outline.OutlineMode = Outline.Mode.OutlineVisible;
        outline.OutlineWidth = 10f;
        // Set outline of door to red color if never put out all flammable objects
        outline.OutlineColor = Color.red;
        openDoorAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        numberOfCorrectObjects = GameObject.FindGameObjectsWithTag("Correct").Length;

        isLevelClear = numberOfCorrectObjects == 5;

        if(isLevelClear) 
        {
            // Set outline of door to red color if never put out all flammable objects
            outline.OutlineColor = Color.green;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == handTag && isLevelClear)
        {
            Debug.Log("touch door");
            cameraRig.transform.Translate(Vector3.forward * 2);
            openDoorAudio.Play();
            SceneManager.LoadScene(startingScene);
        }
    }
}
