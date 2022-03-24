using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    private Canvas canvas;
    private StartMenuManager startMenu;

    void Awake()
    {
        canvas = GetComponent<Canvas>();
    }
    public void SetUp(StartMenuManager startMenu){
        this.startMenu = startMenu;
        Hide();
    }

    public void Show(){
        canvas.enabled = true;
    }

    public void Hide(){
        canvas.enabled = false;
    }
}
