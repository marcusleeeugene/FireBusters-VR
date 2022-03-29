using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadLevelInstructions : MonoBehaviour
{
    public Text instruction;
    private const string Level05Name = "FireEscapeLevel";
    private string fireEscapeLevelInstructions = "FireEscapeLevel-instructions";

    // Start is called before the first frame update
    void Start()
    {
        LoadFile();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadFile()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        string instructionToLoad = "";
        switch(currentScene) 
        {
            case Level05Name:
                instructionToLoad = fireEscapeLevelInstructions;
                Debug.Log("OI!");
                break;
            default:
                break;
        }

        TextAsset txt = (TextAsset)Resources.Load(instructionToLoad, typeof(TextAsset));
        instruction.text = txt.text;
    }

    
}
