using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoiceEnable : MonoBehaviour {

    public Slider voiceSlider;

	public void on_Button_Checked()
    {       
       voiceSlider.interactable = !voiceSlider.interactable;
    }
    
}
