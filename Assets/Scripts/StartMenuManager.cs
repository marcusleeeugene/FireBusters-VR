using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuManager : MonoBehaviour
{

    public Panel currentPanel;
    private Canvas canvas;
    private List<Panel> panelHistory = new List<Panel>();
    private Toggle toggle;
    
    void Awake(){
        canvas = GetComponent<Canvas>();
    }
    // Start is called before the first frame update
    void Start()
    {
        SetupPanels();
    }

    // Update is called once per frame
    void Update()
    {
        // GoToPrevious();
    }

    private void SetupPanels(){
        Panel[] panels = GetComponentsInChildren<Panel>();

        foreach(Panel panel in panels){
            panel.SetUp(this);
        }
        currentPanel.Show();
    }

    public void GoToPrevious(){
        if (panelHistory.Count == 0){
            return;
        }
        int lastIndex = panelHistory.Count - 1;
        SetCurrent(panelHistory[lastIndex]);
        panelHistory.RemoveAt(lastIndex);
    }

    public void SetCurrentWithHistory(Panel newPanel){
        panelHistory.Add(currentPanel);
        SetCurrent(newPanel);
    }

    public void SetCurrent(Panel newPanel){
        currentPanel.Hide();
        currentPanel = newPanel;
        currentPanel.Show();
    }

    public void StartGame(){
        canvas.enabled = false;
    }

    public void EnableSound(Toggle toggle){
        if (toggle.isOn){
            Debug.Log("Help me integrate this part!!! Sound enabled...");        
        } else {
            Debug.Log("Help me integrate this part!!! Sound disabled...");
        }
    }

    public void AdjustVolume(Slider slider){
        // song.volume = slider.value;
        Debug.Log("Current Volume is " +  slider.value.ToString());
    }
}
