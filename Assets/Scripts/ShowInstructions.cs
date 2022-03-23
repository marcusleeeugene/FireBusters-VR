using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShowInstructions : MonoBehaviour
{
    public Text instruction;

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
        TextAsset txt = (TextAsset)Resources.Load("Level05-instructions", typeof(TextAsset));
        instruction.text = txt.text;
    }

    
}
