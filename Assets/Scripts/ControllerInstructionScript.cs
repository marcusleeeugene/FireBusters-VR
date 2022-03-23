using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ControllerInstructionScript : MonoBehaviour
{
    public GameObject instructionPanel;
    private bool showInstruction = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleInstruction() {
        if(showInstruction) {
            instructionPanel.SetActive(true);
        } else {
            instructionPanel.SetActive(false);
        }
        showInstruction = !showInstruction;
    }
}
