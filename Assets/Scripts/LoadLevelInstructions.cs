using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadLevelInstructions : MonoBehaviour
{
    public Text instruction;
    private const string FireClassLevel = "FireClassLevel";
    private const string FireEscapeLevel = "FireEscapeLevel";
    private const string SandboxLevel = "SandboxLevel";
    private string fireEscapeLevelInstructions = "FireEscapeLevel-instructions";
    private string fireClassLevelInstructions = "FireClassLevel-instructions";
    private string sandboxLevelInstructions = "SandboxLevel-instructions";
    private string gameInstructions = "Game-instructions";

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
            case FireClassLevel:
                instructionToLoad = fireClassLevelInstructions;
                break;
            case SandboxLevel:
                instructionToLoad = sandboxLevelInstructions;
                break;
            case FireEscapeLevel:
                instructionToLoad = fireEscapeLevelInstructions;
                break;
            default:
                instructionToLoad = gameInstructions;
                break;
        }

        TextAsset txt = (TextAsset)Resources.Load(instructionToLoad, typeof(TextAsset));
        instruction.text = txt.text;
    }

    
}
