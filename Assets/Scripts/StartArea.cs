using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StartArea : MonoBehaviour
{
    public GameObject lockedEntry;
    public GameObject unlockedEntry;
    public GameObject rightController;
    
    private bool[] levelCompleted = new bool[4];
       
    // Start is called before the first frame update
    void Start(){
        UpdateLevelProgress();
        //levelCompleted[3] = true;
        hideEntryPoints();
        rightController.GetComponent<ControllerManager>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private async void UpdateLevelProgress(){
        string[] levelNames = new string[4];
        levelNames[0] = "Level1";
        levelNames[1] = "Level2";
        levelNames[2] = "Level3";
        levelNames[3] = "Level4";
        for (int i = 0; i < levelNames.Length; i++){
            CheckLevelProgress(levelNames[i], i);
        }
    }

    // Function to check if the PlayerPrefs has the level completion progress, else set as 0. Only exception is level 1 which is set to unlocked.
    private void CheckLevelProgress(string lvlName, int index){
        if (PlayerPrefs.HasKey(lvlName)){
            levelCompleted[index] = IntToBoolean(PlayerPrefs.GetInt(lvlName));
        } else if (String.Equals(lvlName, "Level1")){
            PlayerPrefs.SetInt(lvlName, 1);
            levelCompleted[index] = true;
        } else {
            PlayerPrefs.SetInt(lvlName, 0);
        }
    }

    // Function to convert 1 or 0 into true or false
    private bool IntToBoolean(int value){
        if (value == 1){
            return true;
        } else {
            return false;
        }
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
