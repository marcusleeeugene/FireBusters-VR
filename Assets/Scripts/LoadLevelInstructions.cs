using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadLevelInstructions : MonoBehaviour
{
    public Text instruction;
    private const string Level05Name = "Level05";
    private string level05Instructions = "Level05-instructions";

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
                instructionToLoad = level05Instructions;
                break;
            default:
                break;
        }

        TextAsset txt = (TextAsset)Resources.Load(instructionToLoad, typeof(TextAsset));
        instruction.text = txt.text;
    }

    
}
