using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartArea : MonoBehaviour
{
    public GameObject lockedEntry;
    public GameObject unlockedEntry;
    public GameObject rightController;
    
    private bool[] levelCompleted = new bool[4];
       
    // Start is called before the first frame update
    void Start(){
        levelCompleted[0] = true;
        levelCompleted[3] = true;
        hideEntryPoints();
        rightController.GetComponent<ControllerManager>().enabled = false;
        // displayEntryPoints();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void displayEntryPoints(){
        rightController.GetComponent<ControllerManager>().enabled = true;
        for (int i = 0; i < levelCompleted.Length; i++)
        {
            Debug.Log(lockedEntry.transform.GetChild(i).GetSiblingIndex().ToString());
            lockedEntry.transform.GetChild(i).gameObject.SetActive(!levelCompleted[i]);
            unlockedEntry.transform.GetChild(i).gameObject.SetActive(levelCompleted[i]);
        }
    }

    void hideEntryPoints(){
        for (int i = 0; i < levelCompleted.Length; i++)
        {
            Debug.Log(lockedEntry.transform.GetChild(i).GetSiblingIndex().ToString());
            lockedEntry.transform.GetChild(i).gameObject.SetActive(false);
            unlockedEntry.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
