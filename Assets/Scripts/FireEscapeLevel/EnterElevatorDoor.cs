using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class EnterElevatorDoor : MonoBehaviour
{
    private string handTag = "Hand";
    public GameObject spawnLocation;
    public GameObject cameraRig;
    public GameObject deathVideoScene;
    private VideoPlayer videoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = deathVideoScene.GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += EndVideo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == handTag)
        {
            deathVideoScene.SetActive(true);
            AudioListener.pause = true; 
            cameraRig.transform.position = spawnLocation.transform.position;
        }
    }

    void EndVideo(VideoPlayer vp)
    {
        deathVideoScene.SetActive(false);
        AudioListener.pause = false; 
        LevelStateManager.isTriggerAlarm = false;
    }

}
