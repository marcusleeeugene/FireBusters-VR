using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class StartMenuManager : MonoBehaviour
{
    public GameObject canvasBase;
    public Panel currentPanel;
    public AudioSource soothingMusicAudio;
    public GameObject UIPointer;

    private Canvas canvas;
    private List<Panel> panelHistory = new List<Panel>();
    private Toggle toggle;
    
    void Awake(){
        canvas = GetComponent<Canvas>();
        SetVolume();
    }
    // Start is called before the first frame update
    void Start()
    {
        // PlayerPrefs.SetFloat("SoundVolume", 0.5f);
        // PlayerPrefs.SetInt("HasSeenUI", 0);
        if (PlayerPrefs.HasKey("HasSeenUI") && PlayerPrefs.GetInt("HasSeenUI") == 1){
            Debug.Log("Starting game..." + PlayerPrefs.GetInt("HasSeenUI"));
            StartGame();
            return;
        }
        SetupPanels();
        soothingMusicAudio.Play();
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
        UIPointer.SetActive(false);
        canvasBase.SetActive(false);

    }

    public void QuitGame(){
        if (Application.isEditor){
            UnityEditor.EditorApplication.isPlaying = false;
        } else{
            Application.Quit();
        }
    }

    public void EnableSound(Toggle toggle){
        if (toggle.isOn){
            Debug.Log("Help me integrate this part!!! Sound enabled...");        
        } else {
            Debug.Log("Help me integrate this part!!! Sound disabled...");
        }
    }

    private void SetVolume(){
        if (!PlayerPrefs.HasKey("SoundVolume")){
            PlayerPrefs.SetFloat("SoundVolume", soothingMusicAudio.volume); 
        } 
    }

    public void AdjustVolume(Slider slider){
        // soothingMusicAudio.volume = slider.value;
        // PlayerPrefs.SetFloat("SoundVolume", soothingMusicAudio.volume);
        // Debug.Log("Current Volume is " +  slider.value.ToString());
        PlayerPrefs.SetFloat("SoundVolume", slider.value);
    }
}
