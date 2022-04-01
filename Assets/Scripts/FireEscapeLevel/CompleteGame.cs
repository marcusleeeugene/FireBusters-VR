using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CompleteGame : MonoBehaviour
{
    private string gameControllerTag = "GameController";
    private string startingScene = "Start Point";
    public GameObject endGameScene;
    private VideoPlayer videoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = endGameScene.GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += EndVideo;
        PlayerPrefs.SetInt("HasSeenUI", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == gameControllerTag)
        {
            endGameScene.SetActive(true);
            AudioListener.pause = true; 
        }
    }

    void EndVideo(VideoPlayer vp)
    {
        endGameScene.SetActive(false);
        AudioListener.pause = false; 
        SceneManager.LoadScene(startingScene);
    }
}
