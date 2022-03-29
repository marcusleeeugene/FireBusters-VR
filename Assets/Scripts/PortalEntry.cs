using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class PortalEntry : MonoBehaviour
{
    public AudioSource portalTeleportAudio;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Hand"))
        {
            portalTeleportAudio.Play();
            int levelNumber =  transform.GetSiblingIndex() + 1;     // 1 <= levelNumber <= 4
            Debug.Log(string.Format("Going to level {0} now!!!", levelNumber));
            switch (levelNumber){
                case 1:
                    SceneManager.LoadScene("Level01");
                    break;
                case 2:
                    // SceneManager.LoadScene("Level02");
                    break;
                case 3:
                    SceneManager.LoadScene("SandboxLevel");
                    break;
                case 4:
                    SceneManager.LoadScene("FireEscapeLevel");
                    break;
            }
            
        }
    }
}
