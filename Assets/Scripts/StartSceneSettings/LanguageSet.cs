using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageSet : MonoBehaviour {

    public Toggle chinese;
    public Toggle english;
   
	// Use this for initialization
	void Start () {
        GameSetting.main.language = "Chinese";
        if (GameSetting.main.language=="Chinese")
        {
            chinese.isOn = true;
            english.isOn = false;
        }
        else
        {
            chinese.isOn = false;
            english.isOn = true;
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void on_Chinese_Active()
    {
        GameSetting.main.language = "Chinese";
    }
    public void on_English_Active()
    {
        GameSetting.main.language = "English";
    }


}
