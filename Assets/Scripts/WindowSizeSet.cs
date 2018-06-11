using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
public class WindowSizeSet : MonoBehaviour {

   
    public Toggle full, window;   
	// Use this for initialization
	void Start () {
        if(GameSetting.main.windowSize=="Full")
        {
            full.isOn = true;
        }
        else
        {
            window.isOn = true;
        }
		
	}
	
	// Update is called once per frame
	void Update () {
        
		
	}

    public void on_fullActive()
    {
        PlayerSettings.defaultIsFullScreen = true;
        GameSetting.main.windowSize ="Full";
    }
    public void on_windowActive()
    {
        PlayerSettings.defaultIsFullScreen = false;
        GameSetting.main.windowSize = "Window";
    }
}
