using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AudioSet : MonoBehaviour {
    public Slider mainV;
    public Slider bgV;
    public Slider sound;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameSetting.main.mainVice_isUsed = !mainV.GetComponentInChildren<Toggle>().isOn;
        GameSetting.main.mainVoice = mainV.value;
        GameSetting.main.bgMusic_isUsed =!bgV.GetComponentInChildren<Toggle>().isOn;
        GameSetting.main.bgMusic = bgV.value;
        GameSetting.main.gmSound_isUsed = !sound.GetComponentInChildren<Toggle>().isOn;
        GameSetting.main.gmSound = sound.value;

    }
}
